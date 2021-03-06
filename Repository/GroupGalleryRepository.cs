using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SinglePageApp
{
    public class GroupGalleryRepository : IGroupGallery
    {
        DbSinglePageContext db;
        public GroupGalleryRepository(DbSinglePageContext _db)
        {
            db = _db;
        }
        public void delete(int id)
        {
            var GroupGallery = GetById(id);
            db.Entry(GroupGallery).State = EntityState.Deleted;
            save();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<GroupGallery> GetAllList()
        {
            return db.GroupGallerys.ToList();
        }

        public GroupGallery GetById(int id)
        {
            return db.GroupGallerys.Find(id);
        }

        public void insert(GroupGallery GroupGallery)
        {
            db.GroupGallerys.Add(GroupGallery);
            save();
        }



        public void save()
        {
            db.SaveChanges();
        }

        public void update(GroupGallery GroupGallery)
        {
            db.Entry(GroupGallery).State = EntityState.Modified;
            save();
        }


    }
}