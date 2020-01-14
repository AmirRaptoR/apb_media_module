namespace Farazpardazan.Media
{
    public static class MediaDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = "Media";

        public const string ConnectionStringName = "Media";
    }
}