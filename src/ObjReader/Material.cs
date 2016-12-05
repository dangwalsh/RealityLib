using System.Linq;

using static Reality.ObjReader.Utils;

namespace Reality.ObjReader
{
    // TODO: need to implement setting of scale and origin of texture maps
    internal class Material
    {
        public INode Parent { get; }
        public string Name { get; }
        public Vec4 Kd { get; set; }
        public Vec4 Ka { get; set; }
        public Vec4 Ks { get; set; }
        public string MapKd { get; set; }
        public Vec3 MapKdScale { get; set; }
        public Vec2 MapKdOrigin { get; set; }
        public string MapKa { get; set; }
        public Vec3 MapKaScale { get; set; }
        public Vec2 MapKaOrigin { get; set; }
        public string MapKs { get; set; }
        public Vec3 MapKsScale { get; set; }
        public Vec2 MapKsOrigin { get; set; }
        public string MapBump { get; set; }
        public Vec3 MapBumpScale { get; set; }
        public Vec2 MapBumpOrigin { get; set; }

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

        public void AddBumpMap(string[] tokens)
        {
            var path = ConvertToString(tokens);
            MapBump = path;
        }
    }
}