using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    static class Constants
    {
        public const int TILESIZE = 110;
        public const int PIESESIZE = 80;
        public const int MARKED_PIESESIZE = 90; 
        // Issue could arise if either piesesize or marked_piesesize is larger than tilesize since pieces might overlap
    }
}
