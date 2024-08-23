using System;
using System.Linq.Expressions;
using TodoApp.Core.TodoItem.Models;

namespace TodoApp.Core.TodoItem.Specifications;

  public class TodoItemSpecification
  {
      // Spesifikasi untuk memastikan Title tidak kosong
      public static Expression<Func<Todo, bool>> TitleNotEmpty()
      {
          return item => !string.IsNullOrEmpty(item.Title);
      }

      // Spesifikasi untuk memastikan CreatedDate tidak di masa depan
      public static Expression<Func<Todo, bool>> CreatedDateNotInFuture()
      {
          return item => item.CreatedDate <= DateTime.Now;
      }
  }
