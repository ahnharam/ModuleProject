using PoleServerWithUI.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoleServerWithUI.Utils
{
    public class QueueManager : BindableBase
    {
        static readonly object lck = new Object();

        private Queue<PoleLogModel> poleQueue;
        public Queue<PoleLogModel> PoleQueue
        {
            get { return poleQueue; }
            set { SetProperty(ref poleQueue, value); }
        }

        private static readonly Lazy<QueueManager> lazy = new Lazy<QueueManager>(() => new QueueManager());
        public static QueueManager Instance => lazy.Value;

        public QueueManager()
        {
            PoleQueue = new Queue<PoleLogModel>();
        }

        public void Enqueue(PoleLogModel poleLogModel)
        {
            PoleQueue.Enqueue(poleLogModel);
        }

        public PoleLogModel Dequeue()
        {
            return PoleQueue.Dequeue();
        }

        public int Count => PoleQueue.Count;
    }
}
