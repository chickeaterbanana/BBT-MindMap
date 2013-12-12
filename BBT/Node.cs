﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;

namespace BBT
{
    /// <summary>
    /// Datenklasse für einen Node
    /// </summary>
    class Node : ANode
    {
        Rect grundform;
        ANode parent;
        String text="";
        IStyle stil;
        IForm shape = new Rechteck();

        /// <summary>
        /// gibt Rectangle für die Größe des Grid zurück
        /// </summary>
        /// <returns></returns>
        public override Rect getRectangle()
        {
            if (grundform != null)
                return grundform;
            else
                return new Rect(0, 0, 0, 0);
        }
        /// <summary>
        /// setzt die größe des Rectangle der die Größe des Grids bestimmt
        /// </summary>
        /// <param name="rectangle"></param>
        public override void setRectangle(Rect rectangle)
        {
            this.grundform = rectangle;
            changeNode(this, this);
        }
        /// <summary>
        /// gibt den Elternknoten zurück
        /// </summary>
        /// <returns></returns>
        public override ANode getParent()
        {
            return parent;
        }
        /// <summary>
        /// setzt den Elternknoten
        /// </summary>
        /// <param name="parent"></param>
        public override void setParent(ANode parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// gibt den Text des Knoten zurück
        /// </summary>
        /// <returns></returns>
        public override string getText()
        {
            return text;
        }
        /// <summary>
        /// setzt den Text des Knoten
        /// </summary>
        /// <param name="text"></param>
        public override void setText(string text)
        {
            this.text = text;
            changeNode(this, this);
        }
        /// <summary>
        /// gibt das Styleobjekt eines Nodes zurück
        /// </summary>
        /// <returns></returns>
        public override IStyle getStyle()
        {
            if (stil != null)
                return stil;
            else
                return null;
        }
        /// <summary>
        /// setzt den Style eines Knoten
        /// </summary>
        /// <param name="style"></param>
        public override void setStyle(AStyle style)
        {
            this.stil = style;
            base.setStyle(style);
        }
        /// <summary>
        /// setzt die Form eines Knoten
        /// </summary>
        /// <param name="form"></param>
        public override void setForm(IForm form)
        {
            this.shape = form;
            changeNode(this, this);
        }
        /// <summary>
        /// gibt die Form des Knoten zurück
        /// </summary>
        /// <returns></returns>
        public override IForm getForm()
        {
            if (shape != null)
                return shape;
            else
                return null;
        }
        /// <summary>
        /// wandelt die Daten des Nodes zur Speicherung um
        /// </summary>
        /// <returns></returns>
        public override string toJson()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// setzt Node aus Json
        /// </summary>
        /// <param name="Json"></param>
        public override void fromJson(string Json)
        {
            throw new NotImplementedException();
        }
    }
}
