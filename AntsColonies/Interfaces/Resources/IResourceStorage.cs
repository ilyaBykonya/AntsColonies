namespace AntsColonies
{
    interface IResourceStorage
    {
        public Resources CurrentResources { get; }
        public Resources MaxResources { get; }//Для хранилищ туда надо пропихнуть int.MaxValue
        public Resources TryTakeResources(Resources resources);
        public void TakeResources(Resources resources);
        public void PutResources(Resources resources);
    }
}
