namespace Reality.ObjReader
{
    public static class Facade
    {
        public static int ImportObjects(string filename)
        {
            return GetRoot(filename);
        }

        public static Vec3[] GetVertices()
        {
            return context.Vertices.ToArray();
        }

        public static Vec3[] GetNormals()
        {
            return context.Normals.ToArray();
        }

        public static Vec2[] GetUVs()
        {
            return context.UVs.ToArray();
        }

        public static string GetNameOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Name;
        }

        public static int[] GetVertexIndexOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.VertexIndex.ToArray();
        }

        public static int[] GetNormalIndexOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.NormalIndex.ToArray();
        }

        public static int[] GetUVIndexOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.UVIndex.ToArray();
        }

        public static float[] GetColorOfChannelOfObject(string channel, int index)
        {
            var child = context.Children[index] as Node;
            switch(channel)
            {
                case "Diffuse":
                    return child.Material.Kd;
                case "Ambient":
                    return child.Material.Ka;
                case "Specular":
                    return child.Material.Ks;
                default:
                    return null;
            }
        }

        public static string GetPathOfMapOfObject(string map, int index)
        {
            var child = context.Children[index] as Node;
            switch(map)
            {
                case "Diffuse":
                    return child.Material.MapKd.Path;
                case "Ambient":
                    return child.Material.MapKa.Path;
                case "Specular":
                    return child.Material.MapKs.Path;
                case "Bump":
                    return child.Material.MapBump.Path;
                default:
                    return null;
            }
        }

        public static float[] GetScaleOfMapOfObject(string map, int index)
        {
            var child = context.Children[index] as Node;
            switch(map)
            {
                case "Diffuse":
                    return child.Material.MapKd.Scale;
                case "Ambient":
                    return child.Material.MapKa.Scale;
                case "Specular":
                    return child.Material.MapKs.Scale;
                case "Bump":
                    return child.Material.MapBump.Scale;
                default:
                    return null;
            }
        }

        private static int GetRoot(string filename)
        {
            count = 0;
            context = new Reader(filename).GetRootNode() as Context;
            count = context.Children.Count;
            return count;
        }

        private static Context context;
        private static int count;
    }
}
