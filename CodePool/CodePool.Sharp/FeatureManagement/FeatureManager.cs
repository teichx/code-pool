using Microsoft.FeatureManagement;

namespace CodePool.Sharp.FeatureManagement;

internal sealed class FeatureManager(IFeatureDefinitionProvider featureDefinitionProvider) : IFeatureManager
{
    readonly IFeatureDefinitionProvider _featureDefinitionProvider = featureDefinitionProvider;
    public async IAsyncEnumerable<string> GetFeatureNamesAsync()
    {
        await foreach (var data in _featureDefinitionProvider.GetAllFeatureDefinitionsAsync())
        {
            yield return data.Name;
        }
    }

    public async Task<bool> IsEnabledAsync(string feature)
    {
        var definition = await _featureDefinitionProvider.GetFeatureDefinitionAsync(feature);

        if (string.IsNullOrEmpty(definition.Name)) return false;

        return true;
    }
    public async Task<bool> IsEnabledAsync<TContext>(string feature, TContext context)
    {
        var definition = await _featureDefinitionProvider.GetFeatureDefinitionAsync(feature);

        if (string.IsNullOrEmpty(definition.Name)) return false;

        return true;
    }

    // private async Task<bool> IsEnabledAsync<TContext>(string feature, TContext appContext, bool useAppContext)
    // {
    //     foreach (ISessionManager sessionManager in _sessionManagers)
    //     {
    //         bool? flag = await sessionManager.GetAsync(feature).ConfigureAwait(continueOnCapturedContext: false);
    //         if (flag.HasValue)
    //         {
    //             return flag.Value;
    //         }
    //     }

    //     FeatureDefinition featureDefinition = await _featureDefinitionProvider.GetFeatureDefinitionAsync(feature).ConfigureAwait(continueOnCapturedContext: false);
    //     bool enabled;
    //     if (featureDefinition != null)
    //     {
    //         if (featureDefinition.RequirementType == RequirementType.All && _options.IgnoreMissingFeatureFilters)
    //         {
    //             throw new FeatureManagementException(FeatureManagementError.Conflict, "The 'IgnoreMissingFeatureFilters' flag cannot use used in combination with a feature of requirement type 'All'.");
    //         }

    //         if (featureDefinition.EnabledFor == null || !featureDefinition.EnabledFor.Any())
    //         {
    //             enabled = false;
    //         }
    //         else
    //         {
    //             enabled = featureDefinition.RequirementType == RequirementType.All;
    //             bool targetEvaluation = !enabled;
    //             int filterIndex = -1;
    //             foreach (FeatureFilterConfiguration item in featureDefinition.EnabledFor)
    //             {
    //                 filterIndex++;
    //                 if (string.Equals(item.Name, "AlwaysOn", StringComparison.OrdinalIgnoreCase))
    //                 {
    //                     if (featureDefinition.RequirementType == RequirementType.Any)
    //                     {
    //                         enabled = true;
    //                         break;
    //                     }

    //                     continue;
    //                 }

    //                 IFeatureFilterMetadata filter = GetFeatureFilterMetadata(item.Name);
    //                 if (filter == null)
    //                 {
    //                     DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(61, 2);
    //                     defaultInterpolatedStringHandler.AppendLiteral("The feature filter '");
    //                     defaultInterpolatedStringHandler.AppendFormatted(item.Name);
    //                     defaultInterpolatedStringHandler.AppendLiteral("' specified for feature '");
    //                     defaultInterpolatedStringHandler.AppendFormatted(feature);
    //                     defaultInterpolatedStringHandler.AppendLiteral("' was not found.");
    //                     string message = defaultInterpolatedStringHandler.ToStringAndClear();
    //                     if (!_options.IgnoreMissingFeatureFilters)
    //                     {
    //                         throw new FeatureManagementException(FeatureManagementError.MissingFeatureFilter, message);
    //                     }

    //                     _logger.LogWarning(message);
    //                     continue;
    //                 }

    //                 FeatureFilterEvaluationContext context = new FeatureFilterEvaluationContext
    //                 {
    //                     FeatureName = feature,
    //                     Parameters = item.Parameters
    //                 };
    //                 if (useAppContext)
    //                 {
    //                     ContextualFeatureFilterEvaluator contextualFeatureFilter = GetContextualFeatureFilter(item.Name, typeof(TContext));
    //                     BindSettings(filter, context, filterIndex);
    //                     bool flag2 = contextualFeatureFilter != null;
    //                     if (flag2)
    //                     {
    //                         flag2 = await contextualFeatureFilter.EvaluateAsync(context, appContext).ConfigureAwait(continueOnCapturedContext: false) == targetEvaluation;
    //                     }

    //                     if (flag2)
    //                     {
    //                         enabled = targetEvaluation;
    //                         break;
    //                     }
    //                 }

    //                 IFeatureFilter featureFilter = filter as IFeatureFilter;
    //                 if (featureFilter != null)
    //                 {
    //                     BindSettings(filter, context, filterIndex);
    //                     if (await featureFilter.EvaluateAsync(context).ConfigureAwait(continueOnCapturedContext: false) == targetEvaluation)
    //                     {
    //                         enabled = targetEvaluation;
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     else
    //     {
    //         enabled = false;
    //         string message2 = "The feature declaration for the feature '" + feature + "' was not found.";
    //         if (!_options.IgnoreMissingFeatures)
    //         {
    //             throw new FeatureManagementException(FeatureManagementError.MissingFeature, message2);
    //         }

    //         _logger.LogWarning(message2);
    //     }

    //     foreach (ISessionManager sessionManager2 in _sessionManagers)
    //     {
    //         await sessionManager2.SetAsync(feature, enabled).ConfigureAwait(continueOnCapturedContext: false);
    //     }

    //     return enabled;
    // }
}
