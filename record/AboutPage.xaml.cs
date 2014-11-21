﻿/**
 * Copyright (c) 2013-2014 Microsoft Mobile. All rights reserved.
 * See the license text file for license information.
 */

using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Xml.Linq;
using record.Resources;

namespace record
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            // Application version number

            var version = XDocument.Load("WMAppManifest.xml").Root.Element("App").Attribute("Version").Value;

            var versionRun = new Run()
            {
                Text = String.Format(AppResources.AboutPage_VersionRun, version) + "\n"
            };

            VersionParagraph.Inlines.Add(versionRun);

            // Application about text

            var aboutRun = new Run()
            {
                Text = AppResources.AboutPage_AboutRun + "\n"
            };

            AboutParagraph.Inlines.Add(aboutRun);

            // Link to project homepage

            var projectRunText = AppResources.AboutPage_ProjectRun;
            var projectRunTextSpans = projectRunText.Split(new string[] { "{0}" }, StringSplitOptions.None);

            var projectRunSpan1 = new Run { Text = projectRunTextSpans[0] };

            var projectsLink = new Hyperlink();
            projectsLink.Inlines.Add(AppResources.AboutPage_Hyperlink_Project);
            projectsLink.Click += ProjectsLink_Click;
            projectsLink.Foreground = new SolidColorBrush((Color)Application.Current.Resources["PhoneForegroundColor"]);
            projectsLink.MouseOverForeground = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);

            var projectRunSpan2 = new Run { Text = projectRunTextSpans[1] + "\n" };

            ProjectParagraph.Inlines.Add(projectRunSpan1);
            ProjectParagraph.Inlines.Add(projectsLink);
            ProjectParagraph.Inlines.Add(projectRunSpan2);
        }

        private void ProjectsLink_Click(object sender, RoutedEventArgs e)
        {
            var webBrowserTask = new WebBrowserTask()
            {
                Uri = new Uri(AppResources.AboutPage_Hyperlink_Project, UriKind.Absolute)
            };

            webBrowserTask.Show();
        }
    }
}