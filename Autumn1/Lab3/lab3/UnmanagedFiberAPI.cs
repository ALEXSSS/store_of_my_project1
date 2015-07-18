using System.Runtime.InteropServices;

namespace lab3
{
    internal static class UnmanagedFiberAPI
    {
        public delegate uint LPFIBER_START_ROUTINE(uint param);

        [DllImport("Kernel32.dll")]
        public static extern uint ConvertThreadToFiber(uint lpParameter);
        

        [DllImport("Kernel32.dll")]
        public static extern void SwitchToFiber(uint lpFiber);

        [DllImport("Kernel32.dll")]
        public static extern void DeleteFiber(uint lpFiber);

        [DllImport("Kernel32.dll")]
        public static extern uint CreateFiber(uint dwStackSize, LPFIBER_START_ROUTINE lpStartAddress, uint lpParameter);
    }
}
/*
The problem here is that a fiber cannot delete itself. If ::DeleteFiber is called on the currently running fiber, the entire thread in which the fiber is running will exit because this will call ExitThread. In order to kill the fiber, it switches control to a different fiber, the killFiber. This fiber is able to do a delete operation on the QE object (which, remember, is a subclass of CFiber, and may itself be an instance of some further subclass of QE), which is implemented by a call on ::DeleteFiber, because at that point, the fiber being deleted is not the running fiber.

Note that this appears to be inconsistent with the documentation of DeleteFiber, which states:

If the currently running fiber calls DeleteFiber, its thread calls ExitThread and terminates. However, if a currently running fiber is deleted by another fiber, the thread running the deleted fiber is likely to terminate abnormally because the fiber stack has been freed.

This appears to make no sense at all. Due to the nature of fibers, a “running fiber” cannot be deleted by another fiber (in the same thread), since at the time it is being deleted it is, by definition, not the “running” fiber! However, I suspect that if the paragraph is replaced by one which says (with my suggested changes italicised)

If the currently running fiber calls DeleteFiber, its thread calls ExitThread and terminates. However, if a currently running fiber is deleted by another thread, the thread running the deleted fiber is likely to terminate abnormally because the fiber stack has been freed. If a fiber has been deleted, any attempt to use SwitchToFiber to return control to it is likely to cause its thread to terminate abnormally because the fiber stack has been freed.

I am currently researching this with Microsoft. The current documentation paragraph, as written, would make it impossible to ever call DeleteFiber!
*/
//http://www.codeproject.com/Articles/27410/A-Fiber-Class-and-Friends