using System;
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
        public Texture MapKd { get; set; }
        public Texture MapKa { get; set; }
        public Texture MapKs { get; set; }
        public Texture MapBump { get; set; }

        public Material(INode parent, string name)
        {
            this.Parent = parent;
            this.Name = name;
            this.Kd = new Vec4();
            this.Ka = new Vec4();
            this.Ks = new Vec4();
            this.MapKd = new Texture();
            this.MapKa = new Texture();
            this.MapKs = new Texture();
            this.MapBump = new Texture();
        }

        public void AddD(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.Kd[3] = ConvertToFloat(tokens[0]);
        }

        public void AddKd(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.Kd = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKa(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.Ka = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKs(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.Ks = ConvertToVec3(tokens) + 1.0f;
        }

        public void AddKdMap(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.MapKd = new Texture(tokens);
        }

        public void AddKaMap(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.MapKa = new Texture(tokens);
        }

        public void AddKsMap(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.MapKs = new Texture(tokens);
        }

        public void AddBumpMap(string[] tokens)
        {
            tokens = tokens.Skip(1).ToArray();
            this.MapBump = new Texture(tokens);
        }
    }
}