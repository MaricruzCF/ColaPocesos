namespace ColaProcesos
{
    class Proceso
    {
        public static System.Random random = 
            new System.Random(System.DateTime.Now.Millisecond);

        public Proceso Siguiente;
        public Proceso Anterior;
        public int Ciclos;

        public Proceso()
        {
            this.Ciclos = random.Next(4,15);
        }
    }
}