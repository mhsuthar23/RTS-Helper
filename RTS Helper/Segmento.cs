﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static RTSHelper.Global;



namespace RTSHelper {



    public class Segmento  {


        #region Propiedades

        public TipoSegmento Tipo { get; set; }

        public string Texto { get; set; } // El texto puede ser un texto normal o el texto de una imagen.

        public Formato? Formato { get; set; }

        #endregion Propiedades>


        #region Constructores

        public Segmento(string texto, Formato? formato, TipoSegmento tipo, Formato? formatoPadre, out string? errores) {
            
            errores = null;
            Texto = (tipo == TipoSegmento.Entidad || tipo == TipoSegmento.Imagen) ? texto.ToLowerInvariant() : texto;
            (Formato, Tipo) = (Formato.ObtenerFormatoEfectivo(formato, formatoPadre ?? new Formato(), out string? erroresInternos), tipo);
            AgregarErrores(ref errores, erroresInternos);

        } // Segmento>

        #endregion Constructores>


        #region Procedimientos y Funciones

        public Segmento Clonar(out string? errores) => new Segmento(Texto, Formato, Tipo, new Formato(), out errores);

        #endregion Procedimientos y Funciones>


    } // Segmento>



} // RTSHelper>
