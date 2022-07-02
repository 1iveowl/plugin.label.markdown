namespace MdLabel.Renderer.Blocks
{
    public record MauiListBlockGroup : MauiBlockGroupBase, IMauiListBlockGroup
    {
        //private int _order = 0;
        
        public bool IsOrdered { get; init; }

        public char? OrderDelimiter {get; init;}

        //public int IncrementOrder() =>
        //    IsOrdered
        //        ? OrderStart is not null && OrderStart.Value > 0
        //            ? OrderStart.Value + _order++ - 1
        //            : _order++
        //        : 0;
    }
}
