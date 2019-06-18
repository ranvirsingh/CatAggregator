using CatAggregatorApp.DTO;
using System.Collections.Generic;
using System.Text;

namespace CatAggregatorApp.Processor
{
    public static class HTMLProcessor
    {
        public static string FormatHTML(CatNamesByOwnerGender sortedCatNamesByOwnerGender)
        {
            string resultantHtml = "<html><body>data missing...</body></html>";
            if (sortedCatNamesByOwnerGender != null)
            {
                StringBuilder htmlBody = new StringBuilder();
                foreach (string gender in sortedCatNamesByOwnerGender.Keys)
                {
                    htmlBody.Append($"<h5>{gender}</h5>");
                    htmlBody.Append("<ul>");
                    sortedCatNamesByOwnerGender[gender].ForEach(catName => htmlBody.Append($"<li>{catName}</li>"));
                    htmlBody.Append("</ul>");
                }
                resultantHtml = $"<html><body>{htmlBody}</body></html>";
            }
            return resultantHtml;
        }
    }
}
