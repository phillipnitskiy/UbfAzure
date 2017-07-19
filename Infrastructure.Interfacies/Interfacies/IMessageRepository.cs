namespace Infrastructure.Interfacies.Interfacies
{
    public interface IMessageRepository <TMessageEnity>
    {
        TMessageEnity Get();
        void Add(TMessageEnity entity);
    }
}