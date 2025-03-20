namespace lojaDoDot.infra.data.entity
{
    public class ProductEntity : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Value { get; set; }
        public required UserEntity User { get; set; }
    }
}