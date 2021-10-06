﻿using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor
{
    public partial class RadzenCheckBoxListItem<TValue> : RadzenComponent
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public virtual bool Disabled { get; set; }

        RadzenCheckBoxList<TValue> _checkBoxList;

        [CascadingParameter]
        public RadzenCheckBoxList<TValue> CheckBoxList
        {
            get
            {
                return _checkBoxList;
            }
            set
            {
                if (_checkBoxList != value)
                {
                    _checkBoxList = value;
                    _checkBoxList.AddItem(this);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            CheckBoxList?.RemoveItem(this);
        }

        internal void SetText(string value)
        {
            Text = value;
        }

        internal void SetValue(TValue value)
        {
            Value = value;
        }
    }
}
