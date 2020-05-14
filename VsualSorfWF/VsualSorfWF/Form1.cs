using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsualSorfWF
{
	public partial class Form1 : Form
	{
		public int[] array;

		public Form1()
		{
			InitializeComponent();
		}

        public void mergeSort(int[] arr,
                           int l, int r)
        {
            if (l < r)
            {

        
                int m = l + (r - l) / 2;
                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
            drawSort(array);
            drawMarking();
            Thread.Sleep(60);
        }

        static void merge(int[] arr, int l,
                           int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            /* create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /* Copy data to temp arrays 
            L[] and R[] */
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            /* Merge the temp arrays back  
            into arr[l..r]*/
            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy the remaining elements of 
            L[], if there are any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy the remaining elements of 
            R[], if there are any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }

        }
        /*public Int32[] Merge_sort(Int32[] massive)
        {
            if (massive.Length == 1)
                return massive;
            Int32 mid_point = massive.Length / 2;
            return Merge(Merge_sort(massive.Take(mid_point).ToArray()), Merge_sort(massive.Skip(mid_point).ToArray()));
  
        }

        public Int32[] Merge(Int32[] mass1, Int32[] mass2)
        {
            Int32 a = 0, b = 0;
            Int32[] merged = new int[mass1.Length + mass2.Length];
            for (Int32 i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];

                
            }
            drawSort(array);
            drawMarking();
            Thread.Sleep(100);
            return merged;
        }*/

        private void button1_Click( object sender, EventArgs e )
		{
			Random random = new Random();

			array = new int[(int) countElements.Value];
			array = array.Select( x => random.Next( (int) minLim.Value, (int) ( maxLim.Value + 1 ) ) ).ToArray();

            mergeSort(array, 0, array.Length-1);


            /*for ( int i = 0; i < array.Length; i++ )
			{
				int min = i;
				for ( int j = i + 1; j < array.Length; j++ )
					if ( array[ j ] < array[ min ] )
						min = j;

				if ( min != i )
					swap( ref array[ i ], ref array[ min ] );

				drawSort( array );
				drawMarking();
				Thread.Sleep( 100 );
			}*/
        }

		/*private void swap< T >( ref T a, ref T b )
		{
			T c = a;
			a = b;
			b = c;
		}*/

		private void drawSort( int[] array )
		{
			bool flag = true;
			Pen pen = new Pen( Color.DarkOrange );


			Graphics graphics = pictureBox1.CreateGraphics();
			graphics.Clear( Color.Black );
			for ( int i = (int)minLim.Value; i <= maxLim.Value; i++ )
			{
				for ( int j = 0; j < array.Length; j++ )
				{
					if ( flag )
						pen = new Pen( Color.CornflowerBlue );
					else
						pen = new Pen( Color.DarkOrange );
					flag = !flag;

					if ( array[ j ] >= i )
						graphics.FillRectangle( new SolidBrush( pen.Color ), 15 * j, pictureBox1.Height - 15 * i, 15, 15 );
				}
			}
		}

		private void drawMarking()
		{
			Graphics graphics = pictureBox1.CreateGraphics();

			Pen pen = new Pen( Color.DarkGreen );
			for ( int i = 0; i < pictureBox1.Height; i += 15 )
				graphics.DrawLine( pen, 0, pictureBox1.Height - i, pictureBox1.Width, pictureBox1.Height - i );
			for ( int i = 0; i < pictureBox1.Width; i += 15 )
				graphics.DrawLine( pen, i, 0, i, pictureBox1.Width );
		}

		private void pictureBox1_Paint( object sender, PaintEventArgs e )
		{
			((PictureBox)sender).CreateGraphics().Clear( Color.Black );
			drawMarking();
		}

        
    }
}
