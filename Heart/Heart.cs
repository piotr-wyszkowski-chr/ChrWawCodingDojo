using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace Heart
{
    public class Heart
    {
        private const char TopLeft = '◢';
        private const char TopRight= '◣';
        private const char Middle = '█';
        private const char BottomLeft = '◥';
        private const char BottomRight = '◤';

        public string Draw(int n)
        {
            throw new NotImplementedException();
        }

        public string DrawTop(int width)
        {
            int squares = width / 2 - 2;
            StringBuilder sb = new StringBuilder();
            sb.Append(TopLeft);
            for (int i = 0; i < squares; i++)
            {
                sb.Append(Middle);
            }
            sb.Append(TopRight);
            return sb.ToString() + sb.ToString();
        }
        public string DrawMiddle(int width)
        {
            int lineCnt = width / 6;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lineCnt; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.Append(Middle);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        public string DrawBottom(int width)
        {
            int height = width / 2;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < height; i++)
            {
                StringBuilder line = new StringBuilder();

               

                for (int j = 0; j < i; j++)
                {
                    sb.Append(" ");
                }

                sb.Append(BottomLeft);

                for (int j = 0; j < i; j++)
                {
                    sb.Append(" ");
                }

                sb.Append(line);

                sb.Append(Environment.NewLine);

                
                
            }

            return sb.ToString();
        }


    }
}