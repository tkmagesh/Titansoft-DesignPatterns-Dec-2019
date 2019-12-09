using System.Collections;

namespace ProductsApp
{
    public class ProductsEnumerator : IEnumerator
    {
        private ArrayList _list;

        public ProductsEnumerator(ArrayList list)
        {
            this._list = list;
        }
        private int index = -1;
        public object Current
        {
            get
            {
                return this._list[this.index];
            }
        }

        public bool MoveNext()
        {
            ++this.index;
            if (this.index >= this._list.Count)
            {
                this.Reset();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
