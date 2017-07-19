using System;
using Infrastructure.Interfacies.Interfacies;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Infrastucture.QueueStorage
{
    public class MessageRepository : IMessageRepository<Guid>
    {
        public Guid Get()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Guid entity)
        {
            var queue = QueueStorageHelper.GetQueueFromConfiguration("QueueStorageName");
            queue.AddMessage(new CloudQueueMessage(entity.ToString()));
        }
    }
}