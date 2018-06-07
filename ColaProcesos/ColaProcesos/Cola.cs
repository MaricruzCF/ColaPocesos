namespace ColaProcesos
{
    class Cola
    {
        private Proceso _primero = null;
        private Proceso _ultimo = null;

        public void Encolar(Proceso proceso) // Enqueue
        {
            if (_ultimo != null)
            {
                _ultimo.Siguiente = proceso;
                proceso.Anterior = _ultimo;
                _ultimo = proceso;
            }
            else
                _primero = _ultimo = proceso;
        }

        public Proceso Desencolar()
        {
            if (_primero != _ultimo)
            {
                Proceso primero = _primero;
                Proceso segundo = _primero.Siguiente;
                segundo.Anterior = null;
                primero.Siguiente = null;
                _primero = segundo;

                if (_primero.Siguiente == null)
                    _ultimo = _primero;

                return primero;
            }
            else if (_primero != null)
            {
                Proceso proceso = _primero;
                _primero = _ultimo = null;
                return proceso;
            }
            return null;
        }

        public Proceso Ver()
        {
            return _primero;
        }

        public bool EstaVacia()
        {
            return _primero == null;
        }

        public override string ToString()
        {
            string str = "";
            Proceso temp = _primero;
            while (temp != null)
            {
                temp = temp.Siguiente;
            }
            return str;
        }
        public string ToStringReverse()
        {
            string str = "";
            Proceso temp = _ultimo;
            while (temp != null)
            {
                temp = temp.Anterior;
            }
            return str;
        }
    }
}