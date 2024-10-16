public class ItemDTO
{
    public int ItemID { get; set; }
    public required string ItemName { get; set; }
    public required string RoomName { get; set; }
    public required string RoomID { get; set; }
    public required string ShelfName { get; set; }
    public required string ShelfID { get; set; }
    public int ItemAmount { get; set; }
}