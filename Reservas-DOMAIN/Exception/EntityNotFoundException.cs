

namespace Reservas_DOMAIN.Exception
{
    public class EntityNotFoundException : ReservasException
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(int entityId) : base("Entity with id:" + entityId + " not found") { }
        public EntityNotFoundException(string id, string message) : base(message + " with id:" + id + " not found") { }
        public EntityNotFoundException(int entityId, string message) : base(message + " with id:" + entityId + " not found") { }
    }
}
