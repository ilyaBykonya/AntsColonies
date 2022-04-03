namespace AntsColonies.Interfaces
{
    enum ResourceCode
    {
        Branch = 0x1,
        Leaf = 0x2,
        Stone = 0x4,
        Dewdrop = 0x8
    }
    record Resource(ResourceCode Type);
}
