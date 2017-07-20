using System;

namespace 实现接口事件
{
    public interface IDrawingObject
    {
        event EventHandler OnDraw;
    }

    public interface IShape
    {
        // Raise this event after drawing the shape.
        event EventHandler OnDraw;
    }

    public class Shape : IDrawingObject, IShape
    {
        private event EventHandler PreDrawEvent;

        private event EventHandler PostDrawEvent;

        private object objectLock = new Object();

        // Explicit interface implementation required.
        // Associate IDrawingObject's event with
        // PreDrawEvent
        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    PreDrawEvent -= value;
                }
            }
        }

        // Explicit interface implementation required.
        // Associate IShape's event with
        // PostDrawEvent
        event EventHandler IShape.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PostDrawEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    PostDrawEvent -= value;
                }
            }
        }

        // For the sake of simplicity this one method
        // implements both interfaces.
        public void Draw()
        {
            // Raise IDrawingObject's event before the object is drawn.
            EventHandler handler = PreDrawEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            Console.WriteLine("Drawing a shape.");

            // RaiseIShape's event after the object is drawn.
            handler = PostDrawEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}