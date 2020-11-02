﻿using System;
using System.Linq;
using dotNetCompany.Domain.Repositories.Abstract;
using dotNetCompany.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository: ITextFieldsRepository
    {
        private readonly AppDbContext _context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TextField> GetTextFields()
        {
            return _context.TextFields;
        }

        public TextField GetTextFieldById(Guid id)
        {
            return _context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return _context.TextFields.FirstOrDefault(x => x.CodeWord.ToLower() == codeWord.ToLower());
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            _context.TextFields.Remove(new TextField(){Id = id});
            _context.SaveChanges();
        }
    }
}
