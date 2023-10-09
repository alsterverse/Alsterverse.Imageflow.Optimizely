namespace Alsterverse.Imageflow.Optimizely
{
    public class OptimizelyBlobServiceOptions
    {
        public bool IgnorePrefixCase { get; set; } = true;

        private string[] prefixes = new[] {
            "/episerver/cms/globalassets/",
            "/globalassets/",
            "/episerver/cms/siteassets/",
            "/siteassets/",
            "/episerver/cms/contentassets/",
            "/contentassets/",
        };

        /// <summary>
        /// Ensures the prefix begins and ends with a slash
        /// </summary>
        /// <exception cref="ArgumentException">If prefix is / </exception>
        public string[] Prefixes
        {
            get => prefixes;
            set
            {
                var newList = new List<string>();
                foreach (var str in value)
                {
                    var p = str.TrimStart('/').TrimEnd('/');
                    if (p.Length == 0)
                    {
                        throw new ArgumentException("Prefix cannot be /", nameof(p));
                    }
                    p = '/' + p + '/';
                    newList.Add(p);
                }
                prefixes = newList.ToArray();
            }
        }
    }
}
