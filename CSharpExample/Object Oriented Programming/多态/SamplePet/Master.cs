namespace 多态.SamplePet
{
    internal class Master
    {
        //public void Cure(Dog dog)
        //{
        //    if (dog.Health < 200)
        //    {
        //        dog.Health = 266;
        //        Console.WriteLine("看病好了");
        //    }
        //}

        //public void Cure(Penguin penguin)
        //{
        //    if (penguin.Health < 200)
        //    {
        //        penguin.Health = 266;
        //        Console.WriteLine("看病好了");
        //    }
        //}

        public void Cure(Pet pet)
        {
            pet.ToHospital();
            //if (pet.Health<150)
            //{
            //    pet.Health = 200;
            //    Console.WriteLine("看病好了");
            //}
        }
    }
}