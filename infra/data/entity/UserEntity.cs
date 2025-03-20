using lojaDoDot.infra.model.enumerated;

namespace lojaDoDot.infra.data.entity
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int AccountId { get; set; }
        public required UserType Type { get; set; }
        public required string Document { get; set; }
    }
}