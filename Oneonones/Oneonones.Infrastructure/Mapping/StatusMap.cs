﻿using Oneonones.Domain.Entities;
using Oneonones.Infrastructure.ViewModels;

namespace Oneonones.Infrastructure.Mapping
{
    public static class OneononeStatusMap
    {
        public static StatusViewModel ToViewModel(this StatusEntity entity)
        {
            if (entity == null) return null;

            var viewModel = new StatusViewModel
            {
                NextOccurrence = entity.NextOccurrence,
                LastOccurrence = entity.LastOccurrence,
                IsLate = entity.IsLate,
            };

            return viewModel;
        }
    }
}