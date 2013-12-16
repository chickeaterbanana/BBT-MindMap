﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace BBT
{
    /// <summary>
    /// abstrakte Klasse für alle Nodes
    /// </summary>
    public abstract class ANode
    {
        /// <summary>
        /// true wenn Node geändert wird
        /// </summary>
        private bool _onUpdateing = false;

        /// <summary>
        /// wenn Node geändert werden soll
        /// </summary>
        public void beginUpdate()
        {
            this._onUpdateing = true;
        }

        /// <summary>
        /// wenn nodeänderung abgeschlossen
        /// </summary>
        public void endUpdate()
        {
            this._onUpdateing = false;
            this.changeNode(this, this);
        }

        public abstract Rect getRectangle();
        public abstract void setRectangle(Rect rectangle);

        public abstract ANode getParent();
        public abstract void setParent(ANode parent);

        public abstract string getText();
        public abstract void setText(string text);

        public abstract IStyle getStyle();
        public virtual void setStyle(AStyle style)
        {
            style.changeStyleEvent += this.onChangedStyle;
        }
        
        protected virtual void onChangedStyle(object sender, IStyle node)
        {
            this.changeNode(sender, this);
        }

        public abstract void setForm(IForm form);
        public abstract IForm getForm();

        public Grid getGrid()
        {
            return this.getForm().getStrokeFromNode(this);
        }

        public abstract XElement toXML();
        public abstract void fromXML(XElement XML);

        public delegate void changedNodeEventHandler(object sender, ANode node);

        public event changedNodeEventHandler changeNodeEvent;

        /// <summary>
        /// ein kleiner Wrapper um die Events!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="node"></param>
        protected void changeNode(object sender, ANode node)
        {
            if ((this.changeNodeEvent != null) && (!this._onUpdateing))
                changeNodeEvent(this, node);
        }

        public void invalidate()
        {
            this.changeNode(this, this);
        }
    }
}
