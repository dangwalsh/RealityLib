using System.Linq;

using static Reality.ObjReader.Utils;

namespace Reality.ObjReader
{
    internal class Material
    {
        public INode Parent { get; }
        public string Name { get; }
        public Vec4 Kd { get; set; }
        public Vec4 Ka { get; set; }
        public Vec4 Ks { get; set; }
        public string MapKd { get; set; }
        public string MapKa { get; set; }
        public string MapKs { get; set; }
        public Material(INode parent, string name)
        {
            this.Parent = parent;
            this.Name = name;
        }

        public void AddD(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            Kd[3] = ConvertToFloat(tokens[0]);
        }

        public void AddKd(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            Kd = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKa(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            Ka = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKs(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            Ks = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKdMap(string[] tokens)
        {
            var path = ConvertToString(tokens);
            MapKd = path;
        }

        public void AddKaMap(string[] tokens)
        {
            var path = ConvertToString(tokens);
            MapKa = path;
        }

        public void AddKsMap(string[] tokens)
        {
            var path = ConvertToString(tokens);
            MapKs = path;
        }
    }
}