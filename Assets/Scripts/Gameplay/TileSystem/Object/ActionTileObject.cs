using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CombTeen.Gameplay.Tile.Object
{
    public interface IActionTileData
    {
        public List<string> TileActionTags { get; }
    }

    public class ActionTileObject : TileObject, IActionTileData
    {
        private TileView _view;

        public ActionTileObject(TileView view)
        {
            _view = view;
        }

        public List<string> TileActionTags { private set; get; }

        public virtual void Initial(Vector2 tileCoordinate, params string[] actionTags)
        {
            base.Initial(tileCoordinate);
            TileActionTags = new List<string>(actionTags);
        }

        public bool IsContainTag(string tag)
        {
            return TileActionTags.Contains(tag);
        }
       
        public bool IsContainTags(string[] tags, TagSearch tagSearch = TagSearch.OneOfIt)
        {
            switch (tagSearch)
            {
                case TagSearch.AllOfIt:
                    return ContainAllOfIt();

                default:
                    return ContainOneOfIt();
            }

            bool ContainOneOfIt()
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (TileActionTags.Contains(tags[i])) { return true; }
                }
                return false;
            }
            bool ContainAllOfIt()
            {
                for (int i = 0; i < tags.Length; i++)
                {
                    if (!TileActionTags.Contains(tags[i])) return false;
                }
                return true;
            }
        }

        internal void ChangeColor(Color red)
        {
            _view.ChangeColor(red);
        }

        public enum TagSearch
        {
            OneOfIt,
            AllOfIt
        }
    }
}
