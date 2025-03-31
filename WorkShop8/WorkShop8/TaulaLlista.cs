using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop8
{
        public class TaulaLlista<T> : IList<T>, ICloneable
        {
            const int LONGITUD_INICIAL = 10;
            private T[] dades;
            private int nElem;

            /// <summary>
            /// Crea la TaulaLlista a partir d'una capacitat determinada per l'usuari
            /// </summary>
            /// <param name="capacitat">capacitat de la TaulaLlista</param>
            public TaulaLlista(int capacitat)
            {
                dades = new T[capacitat];
                nElem = 0;
            }

            /// <summary>
            /// Crea la TaulaLlista a partir d'una capacitat predeterminada
            /// </summary>
            public TaulaLlista() : this(LONGITUD_INICIAL) { }

            /// <summary>
            /// Crea la TaulaLlista a partir d'una altre i copia tots els elements de la TaulaLlista passada com a paràmetre
            /// </summary>
            /// <param name="arrayDeDades"></param>
            public TaulaLlista(T[] arrayDeDades)
            {
                dades = new T[arrayDeDades.Length * 2];
                nElem = arrayDeDades.Length;
                for (int i = 0; i < nElem; i++)
                {
                    dades[i] = arrayDeDades[i];
                }
            }

            /// <summary>
            /// La funció duplica la capacitat de la TaulaLlista
            /// </summary>
            private void DoubleCapacity()
            {
                T[] auxiliar = new T[dades.Length * 2];
                for (int i = 0; i < nElem; i++)
                {
                    auxiliar[i] = dades[i];
                }
                dades = auxiliar;
            }

            /// <summary>
            /// Retorna la qüantitat d'elements que tenim
            /// </summary>
            public int Count { get { return nElem; } }

            /// <summary>
            /// Retorna true si la TaulaLlista no és editable. False en cas contrari
            /// </summary>
            public bool IsReadOnly { get { return false; } }

            /// <summary>
            /// Afegeix un element a la llista.
            /// </summary>
            /// <param name="item">element a afegir</param>
            /// <exception cref="NotSupportedException">Array no editable</exception>
            public void Add(T item)
            {
                if (dades.IsReadOnly) throw new NotSupportedException("Array de dades de només lectura");
                if (nElem == dades.Length) DoubleCapacity();
                dades[nElem] = item;
                nElem++;
            }

            /// <summary>
            /// Borra tots els elements de la llista.
            /// </summary>
            /// <exception cref="NotSupportedException">Array no editable</exception>
            public void Clear()
            {
                if (dades.IsReadOnly) throw new NotSupportedException("Array de dades de només lectura");
                for (int i = 0; i < nElem; i++) { dades[i] = default(T); }
                nElem = 0;
            }

            /// <summary>
            /// Comprova si la llista conté un element.
            /// </summary>
            /// <param name="item">element a cercar</param>
            /// <returns></returns>
            public bool Contains(T item)
            {
                bool trobat = false;
                if (IndexOf(item) != -1) trobat = true;
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
                if (array == null) throw new ArgumentNullException("Array null");
                if (arrayIndex < 0) throw new ArgumentOutOfRangeException("Index negatiu");
                if (array.Length - arrayIndex < nElem) throw new ArgumentException("Array no té prou espai"); //Si la long del array - index < que nElem (desborda)
                for (int i = arrayIndex; i < nElem; i++)
                {
                    array[i] = dades[i];
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
                if (IsReadOnly) throw new NotSupportedException("Array de dades de només lectura");
                bool trobat = false;
                int i = IndexOf(item);
                if (i != -1)
                {
                    trobat = true;
                    nElem--;
                    for (int j = i; j < nElem; j++)
                    {
                        dades[j] = dades[j + 1];
                    }
                }
                return trobat;
            }

            /// <summary>
            /// El codi implementa la interfície IEnumerable per permetre la iteració sobre una col·lecció de tipus T
            /// </summary>
            /// <returns></returns>
            public IEnumerator<T> GetEnumerator()
            {
                return new ElMeuEnumerator(dades, nElem);
            }

            /// <summary>
            /// Retorna un IEnumerator no genèric i crida a GetEnumerator() per obtenir l'iterador genèric.
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
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
                else iguals = Equals((TaulaLlista<T>)obj);
                return iguals;
            }

            /// <summary>
            /// Metóde especific per comparar dos elements.
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool Equals(TaulaLlista<T> other)
            {
                bool trobat = false;
                int i = 0;
                while (!trobat && i < nElem)
                {
                    if (dades[i].Equals(other.dades[i])) trobat = true; // utilitzara el metode propi de l'objecte
                    i++;
                }
                return trobat;
            }

            /// <summary>
            /// retorna el HashCode
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            /// <summary>
            /// Retorna el index d'un element en concret.
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public int IndexOf(T item)
            {
                bool trobat = false;
                int i = 0;
                while (!trobat && i < nElem)
                {
                    if (dades[i].Equals(item)) { trobat = true; }
                    else { i++; }
                }
                if (!trobat) i = -1;
                return i;
            }

            /// <summary>
            /// Inserta un element a la TLl especificada.
            /// </summary>
            /// <param name="index">index on es vol afegir</param>
            /// <param name="item">item que es vol afegir</param>
            /// <exception cref="NotSupportedException">Tll no editable</exception>
            /// <exception cref="ArgumentOutOfRangeException">Index fora de rang</exception>
            public void Insert(int index, T item)
            {
                if (IsReadOnly) throw new NotSupportedException("Llista no editable.");
                if (index < 0 || (index >= nElem && nElem != 0)) throw new ArgumentOutOfRangeException("Index fora de rang");
                if (dades.Length == nElem) DoubleCapacity();
                for (int i = nElem - 1; i >= index; i--)
                {
                    dades[i + 1] = dades[i];
                }
                dades[index] = item;
                nElem++;
            }

            /// <summary>
            /// Elimina el element que es troba a l'index especificat.
            /// </summary>
            /// <param name="index"></param>
            /// <exception cref="NotSupportedException">La llista no es pot editar</exception>
            /// <exception cref="ArgumentOutOfRangeException">Index fora de rang</exception>
            public void RemoveAt(int index)
            {
                if (IsReadOnly) throw new NotSupportedException("Llista no editable.");
                if (index < 0 || index >= nElem) throw new ArgumentOutOfRangeException("Index fora de rang");
                for (int i = index; i < nElem - 1; i++)
                {
                    dades[i] = dades[i + 1];
                }
                dades[nElem] = default;
                nElem--;
            }

            /// <summary>
            /// Mètode de clonatje (no implementat).
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotImplementedException">La llista no es pot editar</exception>
            public object Clone()
            {
                throw new NotImplementedException();
            }

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
                    if (index < 0 || index >= nElem) throw new ArgumentOutOfRangeException("Index fora de rang");
                    return dades[index];
                }
                set
                {
                    if (IsReadOnly) throw new NotSupportedException("Llista no editable.");
                    if (index < 0 || index >= nElem) throw new ArgumentOutOfRangeException("Index fora de rang");
                    dades[index] = value;
                }
            }

            /// <summary>
            /// Retorna un array amb totes les dades de la TaulaLlista.
            /// </summary>
            /// <returns>String de tota TLl</returns>
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder("[ ");
                foreach (T element in this)
                {
                    sb.Append(element.ToString() + ", ");
                }
                sb.Length -= 2; // Borrem l'ultim espai i coma
                sb.Append(" ]");
                return sb.ToString();
            }

            public class ElMeuEnumerator : IEnumerator<T>
            {
                private int limit; // Nombre d'elements a recórrer
                private int posicio; // Posició actual en la iteració
                public T[] dades; // Array de dades a recórrer

                /// <summary>
                /// Constructor de l'enumerador.
                /// </summary>
                /// <param name="dades">Array d'elements.</param>
                /// <param name="nElements">Nombre d'elements a recórrer.</param>
                public ElMeuEnumerator(T[] dades, int nElements)
                {
                    this.dades = dades;
                    this.posicio = -1;
                    this.limit = nElements;
                }

                /// <summary>
                /// Obté l'element actual de la iteració.
                /// </summary>
                /// <exception cref="Exception">Llança una excepció si la posició és invàlida.</exception>
                public T Current
                {
                    get
                    {
                        if (posicio == -1 || posicio >= limit) throw new Exception("Fora de rang");
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
                    if (posicio + 1 < limit) { posicio++; realitzat = true; }
                    return realitzat;
                }

                /// <summary>
                /// Reinicia la posició de l'enumerador.
                /// </summary>
                public void Reset()
                {
                    posicio = -1;
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
    }
