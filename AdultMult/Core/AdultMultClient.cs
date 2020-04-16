using AdultMult.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace AdultMult.Core
{
    public class AdultMultClient
    {
        private const string URL = "https://adultmult.club/";
        private readonly string ACTUAL_URL = string.Empty;

        public List<Mult> Mults { get; private set; }

        public AdultMultClient()
        {
            ACTUAL_URL = GetActualUrl();
            Mults = GetMults();
        }

        private string GetActualUrl()
        {
            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(URL);
            var node = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/section[1]/footer[1]/a[1]");

            return node?.Attributes["href"].Value;
        }

        private List<Mult> GetMults()
        {
            List<Mult> multsList = new List<Mult>();
            HtmlWeb web = new HtmlWeb();

            var parentNodeXPath = "//div[contains(concat(' ', normalize-space(@class), ' '), ' organic')]//div[contains(concat(' ', normalize-space(@class), ' '), ' indicator')]";

            var htmlDoc = web.Load(ACTUAL_URL);
            var nodes = htmlDoc.DocumentNode.SelectNodes(parentNodeXPath);

            var imageNodeXPath = ".//img";
            var russianCaptionNodeXPath = ".//span[@class ='live_namerus']";
            var englishCaptionNodeXPath = ".//span[@class ='live_nameeng']";
            var seriesNodeXPath = ".//span[@class ='live_series']";

            foreach (var node in nodes)
            {
                Mult multObject = new Mult
                {
                    Thumbnail = node.SelectSingleNode(imageNodeXPath).Attributes["src"].Value,
                    RussianCaption = node.SelectSingleNode(russianCaptionNodeXPath).InnerText,
                    EnglishCaption = node.SelectSingleNode(englishCaptionNodeXPath).InnerText,
                    Series = node.SelectSingleNode(seriesNodeXPath).InnerText
                };

                multsList.Add(multObject);
            }

            return multsList;
        }
    }
}
