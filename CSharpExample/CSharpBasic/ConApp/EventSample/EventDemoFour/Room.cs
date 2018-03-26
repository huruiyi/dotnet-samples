namespace ConApp.EventSample.EventDemoFour
{
    public class Room
    {
        public Room()
        {
        }

        public void AddMaster(Master master)
        {
            _roomMaster = master;
        }

        public void AddCat(Cat cat)
        {
            _roomCat = cat;
            if (_roomMaster != null)
            {
                cat.OnShout += _roomMaster.Wakeup;
            }
            if (_roomMouse != null)
            {
                cat.OnShout += _roomMouse.RunAway;
            }
        }

        public void AddMouse(Mouse mouse)
        {
            _roomMouse = mouse;
        }

        private Master _roomMaster;
        private Cat _roomCat;
        private Mouse _roomMouse;
    }
}