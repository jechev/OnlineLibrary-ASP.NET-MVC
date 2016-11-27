namespace OnlineLibrary.Web.HtmlExtensions
{
    using System.Web.Mvc;

    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(
            this HtmlHelper helper,
            string imageUrl,
            int width,
            int height,
            string altText = "")
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", "/media/covers/" + imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.Attributes["width"] = width + "px";
            imgBuilder.Attributes["width"] = height + "px";
            imgBuilder.MergeAttribute("class", "img-rounded");

            return new MvcHtmlString(imgBuilder.ToString());
        }
    }
}