using System.IO;
using System.Linq;

namespace Reality.ObjReader
{
    internal class Reader
    {
        static string filepath;
        public static string Filepath
        {
            get { return filepath; }
            private set
            {
                filepath = value;
                Directory = Utils.ExtractDirectory(filepath);
            }
        }

        static string directory;
        public static string Directory
        {
            get { return directory; }
            private set { directory = value; }
        }

        public Reader(string filename)
        {
            Filepath = filename;
        }

        public INode GetRootNode()
        {
            string[] lines = Read(Filepath);
            return BuildContext(lines);
        }

        public static string[] Tokenize(string line)
        {
            return line.Split();
        }

        public static string[] Tokenize(string line, char separator)
        {
            return line.Split(separator);
        }

        public static string[] Read(string filename)
        {
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch (FileNotFoundException)
            {
                filename = Directory + Path.DirectorySeparatorChar + filename;
                lines = File.ReadAllLines(filename);
            }
            return lines;
        }

        protected INode BuildContext(string[] lines)
        {
            var context = Context.GetNewContext;
            foreach (var line in lines)
            {
                var tokens = Tokenize(line as string);
                switch (tokens[0])
                {
                    case "g":
                        context.AddChild(tokens, NodeType.Group);
                        break;
                    case "o":
                        context.AddChild(tokens, NodeType.Object);
                        break;
                    case "v":
                        context.AddVertex(tokens);
                        break;
                    case "vt":
                        context.AddUV(tokens);
                        break;
                    case "vn":
                        context.AddNormal(tokens);
                        break;
                    case "f":
                        context.Children
                            .OfType<Node>()
                            .Last()
                            .AddIndices(tokens);
                        break;
                    case "usemtl":
                        context.Children
                            .OfType<Node>()
                            .Last()
                            .AddMaterial(tokens);
                        break;
                    case "mtllib":
                        context.AddMaterialLibrary(tokens);
                        break;
                    default:
                        break;
                }
            }
            context.Center();
            return context;
        }
    }
}