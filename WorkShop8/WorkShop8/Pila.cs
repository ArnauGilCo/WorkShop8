using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop8
{
    class Pila<T> : ICollection<T>
    {
        T[] data;
        private const int DEFAULT_SIZE = 10;
        private int top = -1;

        /// <summary>
        /// Crea una pila a partir de la mida predeterminada.
        /// </summary>
        public Pila()
        {
            data = new T[DEFAULT_SIZE];
        }

        /// <summary>
        /// Crea una pila a partir de la mida especificada com a paràmetre
        /// </summary>
        /// <param name="size">Mida de creació</param>
        public Pila(int size)
        {
            data = new T[size];
        }

        /// <summary>
        /// Crea una pila a partir d'una Llista Ienumerable especificada com a paràmetre
        /// </summary>
        /// <param name="t">Llista de plantilla</param>
        public Pila(IEnumerable<T> t) // Comprovar
        {
            data = new T[t.Count() * 2];
            int index = 0;
            foreach (T element in t)
            {
                data[index] = element;
                index++;
            }
            top = t.Count() - 1;
        }

        /// <summary>
        /// Retorna la qüantitat d'elements que tenim
        /// </summary>
        public int Count { get { return top + 1; } }

        /// <summary>
        /// Retorna true si la TaulaLlista no és editable. False en cas contrari
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Retorna la referencia al element especificat per paràmetre
        /// </summary>
        /// <param name="index">index del element en qüestió</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">La llista no es pot editar</exception>
        /// <exception cref="ArgumentOutOfRangeException">"Index fora de rang")</exception>
        public T this[int index]
        {
            get
            {
                if (IsReadOnly) throw new NotSupportedException("Llista no editable.");
                if (index < 0 || index >= top) throw new ArgumentOutOfRangeException("Index fora de rang");
                return data[index];
            }
        }

        /// <summary>
        /// Retora la capacitat màxima de la pila.
        /// </summary>
        public int Capacity { get { return data.Length; } }

        /// <summary>
        /// Retorna true si la pila és plena.
        /// </summary>
        public bool IsFull { get { return Count == Capacity; } }

        /// <summary>
        /// Retorna true si la pila és buida.
        /// </summary>
        public bool IsEmpty { get { return top == -1; } }

        /// <summary>
        /// Mètode no implementat
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(T item) // NO FER
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Borra tots els elements de la llista.
        /// </summary>
        /// <exception cref="NotSupportedException">Array no editable</exception>
        public void Clear()
        {
            if (data.IsReadOnly) throw new NotSupportedException("Array de dades de només lectura");
            for (int i = top; i >= 0; i--) { data[i] = default(T); }
            top = -1;
        }

        /// <summary>
        /// Comprova si la llista conté un element.
        /// </summary>
        /// <param name="item">element a cercar</param>
        /// <returns>true en cas de que el trobi</returns>
        public bool Contains(T item)
        {
            bool trobat = false;
            int comptador = top;
            while (!trobat && comptador >= 0)
            {
                if (data[comptador].Equals(item)) trobat = true;
                comptador--;
            }
            return trobat;
        }

        /// <summary>
        ///  Copia els elements de la llista a un nou array.
        /// </summary>
        /// <param name="array">Array on copiar-ho</param>
        /// <param name="arrayIndex">Index d'inici de la còpia</param>
        /// <exception cref="ArgumentNullException">Array passat = null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Index de l'array fora de rang</exception>
        /// <exception cref="ArgumentException">Array massa petit per la còpia.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("array null.");
            if (arrayIndex < 0) throw new ArgumentException("Índex negatiu.");
            if (array.Length - arrayIndex < top) throw new ArgumentException("Array no té prou espai.");
            foreach (T element in this)
            {
                array[arrayIndex] = element;
                arrayIndex++;
            }
        }

        /// <summary>
        /// Elimina el primer element de la llista el qual coincideix amb item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">Tll no editable</exception>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna l'element superior de la pila i l'elimina.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Pila és buida.</exception>
        public T Pop()
        {
            T item;
            if (IsEmpty) throw new InvalidOperationException("Pila buida.");
            item = data[top];
            data[top] = default(T);
            top--;
            return item;
        }

        /// <summary>
        /// Retorna l'element superior de la pila
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Pila és buida.</exception>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Pila buida.");
            return data[top];
        }

        /// <summary>
        /// Afegeix a la pila l'element de paràmetre
        /// </summary>
        /// <param name="item">element a afegir</param>
        /// <exception cref="StackOverflowException"></exception>
        public void Push(T item)
        {
            if (IsFull) throw new StackOverflowException("Pila plena.");
            top++;
            data[top] = item;
        }

        /// <summary>
        /// Crea un array a partir d'una pila
        /// </summary>
        /// <returns>array</returns>
        public T[] ToArray()
        {
            T[] arrayRetorn = new T[top + 1];
            int pos = 0;
            foreach (T element in this)
            {
                arrayRetorn[pos] = element;
                pos++;
            }
            return arrayRetorn;
        }

        /// <summary>
        /// Canvia la longitud de la pila a la especificada per paràmetre.
        /// </summary>
        /// <param name="newCapacity">nova capcitat</param>
        /// <returns>nova capacitat</returns>
        public int EnsureCapacity(int newCapacity)
        {
            if (Capacity < newCapacity)
            {
                T[] novaPila = new T[newCapacity];
                for (int i = 0; i <= top; i++)
                {
                    novaPila[i] = data[i];
                }
                data = novaPila;
            }
            return newCapacity;
        }

        /// <summary>
        /// Filtra els dos objectes a comparar fins a que siguin comparables, si és aixi crida al métode especific.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            bool iguals = false;
            if (ReferenceEquals(null, obj)) iguals = false;
            else if (ReferenceEquals(this, obj)) iguals = true;
            else if (obj.GetType() != this.GetType()) iguals = false;
            else iguals = Equals((Pila<T>)obj);
            return iguals;
        }

        /// <summary>
        /// Retorna true només si tots els elements de les dos piles són iguals.
        /// </summary>
        /// <param name="other">Pila a comparar</param>
        /// <returns>true si son iguals</returns>
        public bool Equals(Pila<T> other)
        {
            bool trobat = true;
            int i = 0;
            if (this.Count() != other.Count()) trobat = false;
            else
            {
                while (trobat && i < top)
                {
                    if (!(data[i].Equals(other.data[i]))) trobat = false; // utilitzara el metode propi de l'objecte
                    i++;
                }
            }
            return trobat;
        }

        /// <summary>
        /// Crea un array amb tots els elements de la pila entre [].
        /// </summary>
        /// <returns>Array de contigut de la pila.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[ ");
            foreach (T element in this)
            {
                sb.Append(element.ToString() + ", ");
            }
            sb.Length -= 2; // Borrem l'ultim espai i coma
            if (sb.Length > 2) sb.Append(" ]");
            return sb.ToString();
        }

        /// <summary>
        /// El codi implementa la interfície IEnumerable per permetre la iteració sobre una col·lecció de tipus T
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorPila(data, top);
        }

        /// <summary>
        /// Retorna un IEnumerator no genèric i crida a GetEnumerator() per obtenir l'iterador genèric.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public class EnumeradorPila : IEnumerator<T>
        {
            private int limit; // Limit de la pila
            private int posicio; // Posicio
            private int indexTop; // Posicio d'inci
            public T[] dades; // Pila de dadaes

            /// <summary>
            /// Constructor de l'enumerador.
            /// </summary>
            /// <param name="dades">Array d'elements.</param>
            /// <param name="top">índex inicial d'on començar a recorrer.</param>
            public EnumeradorPila(T[] dades, int top)
            {
                this.dades = dades;
                this.posicio = top + 1;
                this.limit = -1;
                indexTop = top + 1;
            }

            /// <summary>
            /// Obté l'element actual de la iteració.
            /// </summary>
            /// <exception cref="Exception">Llança una excepció si la posició és invàlida.</exception>
            public T Current
            {
                get
                {
                    if (posicio <= limit || posicio >= dades.Length) throw new IndexOutOfRangeException("Índex fora de rang.");
                    return dades[posicio];
                }
            }


            object IEnumerator.Current => Current;

            /// <summary>
            /// Avança a l'element següent de l'array.
            /// </summary>
            /// <returns>True si avança correctament, false si ha arribat al final.</returns>
            public bool MoveNext()
            {
                bool realitzat = false;
                if (posicio - 1 > limit) { posicio--; realitzat = true; }
                return realitzat;
            }

            /// <summary>
            /// Reinicia la posició de l'enumerador.
            /// </summary>
            public void Reset()
            {
                posicio = indexTop;
            }

            /// <summary>
            /// Mètode per alliberar recursos
            /// </summary>
            public void Dispose()
            {
                this.dades = null;
            }
        }
    }
