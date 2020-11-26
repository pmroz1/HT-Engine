using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace HT_Engine.Graphics
{
    class ContentPipe
    {
        public static int LoadTexture(string path)
        {
            if (!File.Exists("Assets/" + path))
            {
                throw new FileNotFoundException("File not found at \'Asstes/\'" + path);
            }

            int id = GL.GenTexture();

            //GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(sfactor: BlendingFactor.SrcAlpha, dfactor: BlendingFactor.OneMinusSrcAlpha);

            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap("Assets/" + path);

            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppRgb
            );

            //GL.PixelStore(PixelStoreParameter.UnpackRowLength, data.Width * 4); // 4x for 32bpp

            GL.TexImage2D(
                TextureTarget.Texture2D, 0,
                PixelInternalFormat.Rgba,
                data.Width,
                data.Height,
                0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0
            );

            bmp.UnlockBits(data);

            GL.TexParameter(
                TextureTarget.Texture2D, 
                TextureParameterName.TextureWrapS, 
                (int)TextureWrapMode.Clamp
            );

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureWrapT,
                (int)TextureWrapMode.Clamp
            );

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear
            );

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear
            );

            return id;
        }
    }
}
