namespace EPSI.DTOs
{
    public class ItemDTO
    {
        public int ItemID { get; set; }
        public required string ItemName { get; set; }
        public required string RoomName { get; set; }
        public required int RoomID { get; set; }
        public required int ShelfID { get; set; }
        public int ItemAmount { get; set; }
    }
}
