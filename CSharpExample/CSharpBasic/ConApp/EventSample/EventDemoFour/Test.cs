namespace ConApp.EventSample.EventDemoFour
{
    public class Test
    {
        public static void Demo()
        {
            //1. 有个人有两只宠物，
            //一只猫，一支狗，用程序实现，
            //当这个人说了句“Bye Bye后”
            //让狗和猫分别发出“汪汪” 和 “喵喵”。

            //2. 主人在房间睡觉，
            //客厅内一只老鼠正在偷吃蛋糕，
            //客厅地毯上一只猫睡醒后叫了一声“喵喵”，
            //唤醒了主人，吓跑了老鼠。

            Master master = new Master();
            Cat cat = new Cat();
            Mouse mouse = new Mouse();

            Room r = new Room();
            r.AddMaster(master);
            master.Sleep("房间");
            r.AddMouse(mouse);
            mouse.CatlikeEat("客厅", "蛋糕");
            r.AddCat(cat);
            cat.Sleep("客厅");
            cat.Shout();
        }
    }
}