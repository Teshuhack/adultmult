﻿using AdultMult.DataProvider;
using AdultMult.Models;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdultMult.Services
{
    public class AdultMultService : IAdultMultService
    {
        private const string URL = "https://adultmult.club/";

        private readonly AdultMultContext _adultMultContext;

        public AdultMultService(AdultMultContext adultMultContext)
        {
            _adultMultContext = adultMultContext;
        }

        private string GetActualUrl()
        {
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(URL);
            var node = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/section[1]/footer[1]/a[1]");

            return node?.Attributes["href"].Value;
        }

        public async Task ParseMultsAsync()
        {
            HtmlWeb web = new HtmlWeb();

            var actualUrl = GetActualUrl();
            var parentNodeXPath = "//div[contains(concat(' ', normalize-space(@class), ' '), ' organic')]//div[contains(concat(' ', normalize-space(@class), ' '), ' indicator')]";

            var htmlDoc = web.Load(actualUrl);
            var nodes = htmlDoc.DocumentNode.SelectNodes(parentNodeXPath);

            var russianCaptionNodeXPath = ".//span[@class ='live_namerus']";
            var seriesNodeXPath = ".//span[@class ='live_series']";

            foreach (var node in nodes)
            {
                Mult multObject = new Mult
                {
                    RussianCaption = node.SelectSingleNode(russianCaptionNodeXPath).InnerText,
                    Series = node.SelectSingleNode(seriesNodeXPath).InnerText,
                    UpdateDate = DateTime.Now.Date
                };

                var existingMult = _adultMultContext.Mults.FirstOrDefault(x => x.RussianCaption == multObject.RussianCaption);
                if (existingMult != null)
                {
                    if (multObject.Series != existingMult.Series)
                    {
                        existingMult.Series = multObject.Series;
                        existingMult.IsUpdated = true;
                        await _adultMultContext.SaveChangesAsync();
                    }
                }
                else
                {
                    multObject.IsUpdated = true;
                    await _adultMultContext.Mults.AddAsync(multObject);
                }
            }

            await _adultMultContext.SaveChangesAsync();
        }
    }
}
