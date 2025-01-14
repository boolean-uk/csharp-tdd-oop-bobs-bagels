namespace exercise.main
{
    public class StoreFrontExecutor
    {
        IStoreFront storeFront;
        public StoreFrontExecutor(IStoreFront storeFront)
        {
            this.storeFront = storeFront;
        }

        public void run()
        {
            storeFront.run();
        }

    }

}
