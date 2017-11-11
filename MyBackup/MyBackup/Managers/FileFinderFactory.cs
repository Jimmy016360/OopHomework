namespace MyBackup
{
    public static class FileFinderFactory
    {
        public static IFileFinder Create(string finder, Config config)
        {
            if (finder == "file")
                return new LocalFileFinder(config);
            else
                return null;
        }
    }
}