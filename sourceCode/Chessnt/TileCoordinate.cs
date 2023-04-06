using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;

namespace Chessnt
{
    public class Bruh
    {
        private int originX;//a1
        private int originY;
        #region yes
        public TileCoordinate a1;
        public TileCoordinate a2;
        public TileCoordinate a3;
        public TileCoordinate a4;
        public TileCoordinate a5;
        public TileCoordinate a6;
        public TileCoordinate a7;
        public TileCoordinate a8;
        public TileCoordinate b1;
        public TileCoordinate b2;
        public TileCoordinate b3;
        public TileCoordinate b4;
        public TileCoordinate b5;
        public TileCoordinate b6;
        public TileCoordinate b7;
        public TileCoordinate b8;
        public TileCoordinate c1;
        public TileCoordinate c2;
        public TileCoordinate c3;
        public TileCoordinate c4;
        public TileCoordinate c5;
        public TileCoordinate c6;
        public TileCoordinate c7;
        public TileCoordinate c8;
        public TileCoordinate d1;
        public TileCoordinate d2;
        public TileCoordinate d3;
        public TileCoordinate d4;
        public TileCoordinate d5;
        public TileCoordinate d6;
        public TileCoordinate d7;
        public TileCoordinate d8;
        public TileCoordinate e1;
        public TileCoordinate e2;
        public TileCoordinate e3;
        public TileCoordinate e4;
        public TileCoordinate e5;
        public TileCoordinate e6;
        public TileCoordinate e7;
        public TileCoordinate e8;
        public TileCoordinate f1;
        public TileCoordinate f2;
        public TileCoordinate f3;
        public TileCoordinate f4;
        public TileCoordinate f5;
        public TileCoordinate f6;
        public TileCoordinate f7;
        public TileCoordinate f8;
        public TileCoordinate g1;
        public TileCoordinate g2;
        public TileCoordinate g3;
        public TileCoordinate g4;
        public TileCoordinate g5;
        public TileCoordinate g6;
        public TileCoordinate g7;
        public TileCoordinate g8;
        public TileCoordinate h1;
        public TileCoordinate h2;
        public TileCoordinate h3;
        public TileCoordinate h4;
        public TileCoordinate h5;
        public TileCoordinate h6;
        public TileCoordinate h7;
        public TileCoordinate h8;
        #endregion

        public Bruh()
        {
            this.originX = 595;
            this.originY = 940;
            CreateCoordinate();
        }

        public int GoUp(int y, int multiply) {
            return y - (110 * multiply); 
        }
        public int GoRight(int x, int multiply)
        {
            return x + (110 * multiply);
        }

        public void CreateCoordinate()
        {
            this.a1 = new TileCoordinate(originX, originY);
            this.a2 = new TileCoordinate(originX, GoUp(originY,1));
            this.a3 = new TileCoordinate(originX, GoUp(originY,2));
            this.a4 = new TileCoordinate(originX, GoUp(originY, 3));
            this.a5 = new TileCoordinate(originX, GoUp(originY, 4));
            this.a6 = new TileCoordinate(originX, GoUp(originY, 5));
            this.a7 = new TileCoordinate(originX, GoUp(originY, 6));
            this.a8 = new TileCoordinate(originX, GoUp(originY, 7));

            this.b1 = new TileCoordinate(GoRight(originX, 1), originY);
            this.b2 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 1));
            this.b3 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 2));
            this.b4 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 3));
            this.b5 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 4));
            this.b6 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 5));
            this.b7 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 6));
            this.b8 = new TileCoordinate(GoRight(originX, 1), GoUp(originY, 7));

            this.c1 = new TileCoordinate(GoRight(originX, 2), originY);
            this.c2 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 1));
            this.c3 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 2));
            this.c4 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 3));
            this.c5 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 4));
            this.c6 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 5));
            this.c7 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 6));
            this.c8 = new TileCoordinate(GoRight(originX, 2), GoUp(originY, 7));

            this.d1 = new TileCoordinate(GoRight(originX, 3), originY);
            this.d2 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 1));
            this.d3 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 2));
            this.d4 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 3));
            this.d5 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 4));
            this.d6 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 5));
            this.d7 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 6));
            this.d8 = new TileCoordinate(GoRight(originX, 3), GoUp(originY, 7));

            this.e1 = new TileCoordinate(GoRight(originX, 4), originY);
            this.e2 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 1));
            this.e3 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 2));
            this.e4 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 3));
            this.e5 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 4));
            this.e6 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 5));
            this.e7 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 6));
            this.e8 = new TileCoordinate(GoRight(originX, 4), GoUp(originY, 7));

            this.f1 = new TileCoordinate(GoRight(originX, 5), originY);
            this.f2 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 1));
            this.f3 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 2));
            this.f4 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 3));
            this.f5 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 4));
            this.f6 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 5));
            this.f7 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 6));
            this.f8 = new TileCoordinate(GoRight(originX, 5), GoUp(originY, 7));

            this.g1 = new TileCoordinate(GoRight(originX, 6), originY);
            this.g2 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 1));
            this.g3 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 2));
            this.g4 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 3));
            this.g5 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 4));
            this.g6 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 5));
            this.g7 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 6));
            this.g8 = new TileCoordinate(GoRight(originX, 6), GoUp(originY, 7));

            this.h1 = new TileCoordinate(GoRight(originX, 7), originY);
            this.h2 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 1));
            this.h3 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 2));
            this.h4 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 3));
            this.h5 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 4));
            this.h6 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 5));
            this.h7 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 6));
            this.h8 = new TileCoordinate(GoRight(originX, 7), GoUp(originY, 7));
        }
    }


    public class TileCoordinate
    {
        private int X;
        private int Y;

        public TileCoordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int GetX()
        {
            return this.X;
        }

        public int GetY()
        {
            return this.Y;
        }
    }

}
