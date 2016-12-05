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

        public static float[] GetKdOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.Kd;
        }

        public static float[] GetKaOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.Kd;
        }

        public static float[] GetKsOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.Kd;
        }

        public static string GetMapKdOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.MapKd;
        }

        public static string GetMapKaOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.MapKd;
        }

        public static string GetMapKsOfObject(int index)
        {
            var child = context.Children[index] as Node;
            return child.Material.MapKd;
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
