namespace lojaDoDot.infra.data.entity
{
    public class NotificationEntity : BaseEntity
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required bool Pending { get; set; }
        public required bool Accepted { get; set; }
        public required ProductEntity Product { get; set; }
        public required UserEntity User { get; set; }
    }
}