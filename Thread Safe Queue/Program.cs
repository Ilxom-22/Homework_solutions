var a = new Queue<int>();

var customQueue = new CustomQueue<int>();


var tasks = new List<Task>()
{
    new(() => customQueue.EnqueueAsync(5).AsTask()),
    new(() => customQueue.EnqueueAsync(4).AsTask()),
    new(() => customQueue.EnqueueAsync(15).AsTask()),
    new(() => customQueue.EnqueueAsync(11).AsTask()),
    new(() => customQueue.EnqueueAsync(51).AsTask()),
    new(() => customQueue.EnqueueAsync(71).AsTask()),
    new(() => customQueue.EnqueueAsync(18).AsTask()),
    new(() => customQueue.EnqueueAsync(45).AsTask()),
    new(() => customQueue.EnqueueAsync(76).AsTask()),
    new(() => customQueue.EnqueueAsync(90).AsTask()),
    new(() => customQueue.EnqueueAsync(12).AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
    new (() => customQueue.DequeueAnync().AsTask()),
};

Parallel.ForEach(tasks, (task) => task.Start());
await Task.WhenAll(tasks);