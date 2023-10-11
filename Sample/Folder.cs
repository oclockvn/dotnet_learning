namespace Sample
{
    public class File
    {

    }

    public class Folder
    {
        // public|protected|private|internal string|int|bool|char|long|float|Class|List PascalCase {get;set;}
        // [modifier] [datatype] [name] {get;set;}
        public string Name { get; set; }
        public DateTime LastModified { get; set; }

        public List<Folder> SubFolders { get; set; } = new List<Folder>();
        public List<File> Files { get; set; } = new List<File>();
    }

    //public class SubFolder
    //{
    //    public string Name { get; set; }
    //    public DateTime LastModified { get; set; }
    //}

    public class Explorer
    {
        public void Explore()
        {
            var folderA = new Folder();
            folderA.Name = "Folder A";

            var folderB = new Folder()
            {
                Name = "FolderB",
            };

            //var folderC = new Folder("FolderC");

            //var video = new SubFolder { Name = "Video" };
            //var download = new SubFolder { Name = "Download" };
            var subfolders = new List<Folder>()
            {
                new Folder { Name = "Video" },
                new Folder { Name = "Download" },
            };
            //subfolders.Add(video);
            //subfolders.Add(download);

            // primitive
            var home = new Folder
            {
                Name = "Home",
                LastModified = DateTime.Now,
                //SubFolders = new List<SubFolder> 
                //{
                //    new SubFolder{ Name = "Video", LastModified = DateTime.Now},
                //    new SubFolder{ Name = "Downloads", LastModified = DateTime.Now},
                //}
                SubFolders = subfolders,
                //Files = new List<File>
                //{

                //}
            };
            //home.Name = "Home";
            //home.LastModified = DateTime.Now;
            //home.SubFolders = subfolders;
            //home.Files = new List<File> { };
            //home.Add(new File { });
            
        }
    }
}
