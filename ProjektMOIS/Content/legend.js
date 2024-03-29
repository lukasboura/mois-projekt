




<!DOCTYPE html>
<html>
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# object: http://ogp.me/ns/object# article: http://ogp.me/ns/article# profile: http://ogp.me/ns/profile#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <title>Chart.js.legend/src/legend.js at master · bebraw/Chart.js.legend</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub" />
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub" />
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png" />
    <meta property="fb:app_id" content="1401488693436528"/>

      <meta content="@github" name="twitter:site" /><meta content="summary" name="twitter:card" /><meta content="bebraw/Chart.js.legend" name="twitter:title" /><meta content="Chart.js.legend - Legend plugin for Chart.js (MIT)" name="twitter:description" /><meta content="https://avatars.githubusercontent.com/u/166921" name="twitter:image:src" />
<meta content="GitHub" property="og:site_name" /><meta content="object" property="og:type" /><meta content="https://avatars.githubusercontent.com/u/166921" property="og:image" /><meta content="bebraw/Chart.js.legend" property="og:title" /><meta content="https://github.com/bebraw/Chart.js.legend" property="og:url" /><meta content="Chart.js.legend - Legend plugin for Chart.js (MIT)" property="og:description" />

    <meta name="hostname" content="github-fe128-cp1-prd.iad.github.net">
    <meta name="ruby" content="ruby 2.1.0p0-github-tcmalloc (87c9373a41) [x86_64-linux]">
    <link rel="assets" href="https://github.global.ssl.fastly.net/">
    <link rel="conduit-xhr" href="https://ghconduit.com:25035/">
    <link rel="xhr-socket" href="/_sockets" />


    <meta name="msapplication-TileImage" content="/windows-tile.png" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="selected-link" value="repo_source" data-pjax-transient />
    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="collector-cdn.github.com" name="octolytics-script-host" /><meta content="github" name="octolytics-app-id" /><meta content="5263BD0C:5371:92772B0:53149B55" name="octolytics-dimension-request_id" /><meta content="3379935" name="octolytics-actor-id" /><meta content="bouralu89" name="octolytics-actor-login" /><meta content="1bd42ba8abed979f7b666c3e46f4e7a3c500dc8feb8ca077a998af18da671a7d" name="octolytics-actor-hash" />
    

    
    
    <link rel="icon" type="image/x-icon" href="/favicon.ico" />

    <meta content="authenticity_token" name="csrf-param" />
<meta content="rocu28FeyQhHY+A3LsqogypbU5dCtzq+7bK8cizVi+E=" name="csrf-token" />

    <link href="https://github.global.ssl.fastly.net/assets/github-4a8e783d228bdcf2d8e2f6b14f7a9fb453c509b8.css" media="all" rel="stylesheet" type="text/css" />
    <link href="https://github.global.ssl.fastly.net/assets/github2-cb91aec5b799e43ecbc2cb6ac665bc7289f0d01e.css" media="all" rel="stylesheet" type="text/css" />
    
    


      <script crossorigin="anonymous" src="https://github.global.ssl.fastly.net/assets/frameworks-75c3712476c7af863873362d0cdf06a94a4b4fa3.js" type="text/javascript"></script>
      <script async="async" crossorigin="anonymous" src="https://github.global.ssl.fastly.net/assets/github-0a9d4e294873972a56136b7a78254286688653c2.js" type="text/javascript"></script>
      
      <meta http-equiv="x-pjax-version" content="2c4045b5de34ff294993436f4c651f77">

        <link data-pjax-transient rel='permalink' href='/bebraw/Chart.js.legend/blob/98f98debc3b0d985d8839c7ad1406dd3d370b8b7/src/legend.js'>

  <meta name="description" content="Chart.js.legend - Legend plugin for Chart.js (MIT)" />

  <meta content="166921" name="octolytics-dimension-user_id" /><meta content="bebraw" name="octolytics-dimension-user_login" /><meta content="10968794" name="octolytics-dimension-repository_id" /><meta content="bebraw/Chart.js.legend" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="10968794" name="octolytics-dimension-repository_network_root_id" /><meta content="bebraw/Chart.js.legend" name="octolytics-dimension-repository_network_root_nwo" />
  <link href="https://github.com/bebraw/Chart.js.legend/commits/master.atom" rel="alternate" title="Recent Commits to Chart.js.legend:master" type="application/atom+xml" />

  </head>


  <body class="logged_in  env-production windows vis-public page-blob tipsy-tooltips">
    <div class="wrapper">
      
      
      
      


      <div class="header header-logged-in true">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="https://github.com/">
  <span class="mega-octicon octicon-mark-github"></span>
</a>

    
    <a href="/notifications" aria-label="You have no unread notifications" class="notification-indicator tooltipped tooltipped-s" data-gotokey="n">
        <span class="mail-status all-read"></span>
</a>

      <div class="command-bar js-command-bar  in-repository">
          <form accept-charset="UTF-8" action="/search" class="command-bar-form" id="top_search_form" method="get">

<input type="text" data-hotkey="/ s" name="q" id="js-command-bar-field" placeholder="Search or type a command" tabindex="1" autocapitalize="off"
    
    data-username="bouralu89"
      data-repo="bebraw/Chart.js.legend"
      data-branch="master"
      data-sha="9b51f16f519e3a774ec2afc57691bd1ea10bbde2"
  >

    <input type="hidden" name="nwo" value="bebraw/Chart.js.legend" />

    <div class="select-menu js-menu-container js-select-menu search-context-select-menu">
      <span class="minibutton select-menu-button js-menu-target" role="button" aria-haspopup="true">
        <span class="js-select-button">This repository</span>
      </span>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container" aria-hidden="true">
        <div class="select-menu-modal">

          <div class="select-menu-item js-navigation-item js-this-repository-navigation-item selected">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" class="js-search-this-repository" name="search_target" value="repository" checked="checked" />
            <div class="select-menu-item-text js-select-button-text">This repository</div>
          </div> <!-- /.select-menu-item -->

          <div class="select-menu-item js-navigation-item js-all-repositories-navigation-item">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" name="search_target" value="global" />
            <div class="select-menu-item-text js-select-button-text">All repositories</div>
          </div> <!-- /.select-menu-item -->

        </div>
      </div>
    </div>

  <span class="help tooltipped tooltipped-s" aria-label="Show command bar help">
    <span class="octicon octicon-question"></span>
  </span>


  <input type="hidden" name="ref" value="cmdform">

</form>
        <ul class="top-nav">
          <li class="explore"><a href="/explore">Explore</a></li>
            <li><a href="https://gist.github.com">Gist</a></li>
            <li><a href="/blog">Blog</a></li>
          <li><a href="https://help.github.com">Help</a></li>
        </ul>
      </div>

    


  <ul id="user-links">
    <li>
      <a href="/bouralu89" class="name">
        <img alt="bouralu89" class=" js-avatar" data-user="3379935" height="20" src="https://avatars.githubusercontent.com/u/3379935" width="20" /> bouralu89
      </a>
    </li>

    <li class="new-menu dropdown-toggle js-menu-container">
      <a href="#" class="js-menu-target tooltipped tooltipped-s" aria-label="Create new...">
        <span class="octicon octicon-plus"></span>
        <span class="dropdown-arrow"></span>
      </a>

      <div class="new-menu-content js-menu-content">
      </div>
    </li>

    <li>
      <a href="/settings/profile" id="account_settings"
        class="tooltipped tooltipped-s"
        aria-label="Account settings ">
        <span class="octicon octicon-tools"></span>
      </a>
    </li>
    <li>
      <a class="tooltipped tooltipped-s" href="/logout" data-method="post" id="logout" aria-label="Sign out">
        <span class="octicon octicon-log-out"></span>
      </a>
    </li>

  </ul>

<div class="js-new-dropdown-contents hidden">
  

<ul class="dropdown-menu">
  <li>
    <a href="/new"><span class="octicon octicon-repo-create"></span> New repository</a>
  </li>
  <li>
    <a href="/organizations/new"><span class="octicon octicon-organization"></span> New organization</a>
  </li>


    <li class="section-title">
      <span title="bebraw/Chart.js.legend">This repository</span>
    </li>
      <li>
        <a href="/bebraw/Chart.js.legend/issues/new"><span class="octicon octicon-issue-opened"></span> New issue</a>
      </li>
</ul>

</div>


    
  </div>
</div>

      

        




          <div class="site" itemscope itemtype="http://schema.org/WebPage">
    
    <div class="pagehead repohead instapaper_ignore readability-menu">
      <div class="container">
        

<ul class="pagehead-actions">

    <li class="subscription">
      <form accept-charset="UTF-8" action="/notifications/subscribe" class="js-social-container" data-autosubmit="true" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="rocu28FeyQhHY+A3LsqogypbU5dCtzq+7bK8cizVi+E=" /></div>  <input id="repository_id" name="repository_id" type="hidden" value="10968794" />

    <div class="select-menu js-menu-container js-select-menu">
      <a class="social-count js-social-count" href="/bebraw/Chart.js.legend/watchers">
        2
      </a>
      <span class="minibutton select-menu-button with-count js-menu-target" role="button" tabindex="0" aria-haspopup="true">
        <span class="js-select-button">
          <span class="octicon octicon-eye-watch"></span>
          Watch
        </span>
      </span>

      <div class="select-menu-modal-holder">
        <div class="select-menu-modal subscription-menu-modal js-menu-content" aria-hidden="true">
          <div class="select-menu-header">
            <span class="select-menu-title">Notification status</span>
            <span class="octicon octicon-remove-close js-menu-close"></span>
          </div> <!-- /.select-menu-header -->

          <div class="select-menu-list js-navigation-container" role="menu">

            <div class="select-menu-item js-navigation-item selected" role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input checked="checked" id="do_included" name="do" type="radio" value="included" />
                <h4>Not watching</h4>
                <span class="description">You only receive notifications for conversations in which you participate or are @mentioned.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-watch"></span>
                  Watch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_subscribed" name="do" type="radio" value="subscribed" />
                <h4>Watching</h4>
                <span class="description">You receive notifications for all conversations in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye-unwatch"></span>
                  Unwatch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_ignore" name="do" type="radio" value="ignore" />
                <h4>Ignoring</h4>
                <span class="description">You do not receive any notifications for conversations in this repository.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-mute"></span>
                  Stop ignoring
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

          </div> <!-- /.select-menu-list -->

        </div> <!-- /.select-menu-modal -->
      </div> <!-- /.select-menu-modal-holder -->
    </div> <!-- /.select-menu -->

</form>
    </li>

  <li>
  

  <div class="js-toggler-container js-social-container starring-container ">
    <a href="/bebraw/Chart.js.legend/unstar"
      class="minibutton with-count js-toggler-target star-button starred"
      aria-label="Unstar this repository" data-remote="true" data-method="post" rel="nofollow">
      <span class="octicon octicon-star-delete"></span><span class="text">Unstar</span>
    </a>

    <a href="/bebraw/Chart.js.legend/star"
      class="minibutton with-count js-toggler-target star-button unstarred"
      aria-label="Star this repository" data-remote="true" data-method="post" rel="nofollow">
      <span class="octicon octicon-star"></span><span class="text">Star</span>
    </a>

      <a class="social-count js-social-count" href="/bebraw/Chart.js.legend/stargazers">
        20
      </a>
  </div>

  </li>


        <li>
          <a href="/bebraw/Chart.js.legend/fork" class="minibutton with-count js-toggler-target fork-button lighter tooltipped-n" title="Fork this repo" rel="nofollow" data-method="post">
            <span class="octicon octicon-git-branch-create"></span><span class="text">Fork</span>
          </a>
          <a href="/bebraw/Chart.js.legend/network" class="social-count">10</a>
        </li>


</ul>

        <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
          <span class="repo-label"><span>public</span></span>
          <span class="mega-octicon octicon-repo"></span>
          <span class="author">
            <a href="/bebraw" class="url fn" itemprop="url" rel="author"><span itemprop="title">bebraw</span></a>
          </span>
          <span class="repohead-name-divider">/</span>
          <strong><a href="/bebraw/Chart.js.legend" class="js-current-repository js-repo-home-link">Chart.js.legend</a></strong>

          <span class="page-context-loader">
            <img alt="Octocat-spinner-32" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
          </span>

        </h1>
      </div><!-- /.container -->
    </div><!-- /.repohead -->

    <div class="container">
      <div class="repository-with-sidebar repo-container new-discussion-timeline js-new-discussion-timeline  ">
        <div class="repository-sidebar clearfix">
            

<div class="sunken-menu vertical-right repo-nav js-repo-nav js-repository-container-pjax js-octicon-loaders">
  <div class="sunken-menu-contents">
    <ul class="sunken-menu-group">
      <li class="tooltipped tooltipped-w" aria-label="Code">
        <a href="/bebraw/Chart.js.legend" aria-label="Code" class="selected js-selected-navigation-item sunken-menu-item" data-gotokey="c" data-pjax="true" data-selected-links="repo_source repo_downloads repo_commits repo_tags repo_branches /bebraw/Chart.js.legend">
          <span class="octicon octicon-code"></span> <span class="full-word">Code</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

        <li class="tooltipped tooltipped-w" aria-label="Issues">
          <a href="/bebraw/Chart.js.legend/issues" aria-label="Issues" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-gotokey="i" data-selected-links="repo_issues /bebraw/Chart.js.legend/issues">
            <span class="octicon octicon-issue-opened"></span> <span class="full-word">Issues</span>
            <span class='counter'>0</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>

      <li class="tooltipped tooltipped-w" aria-label="Pull Requests">
        <a href="/bebraw/Chart.js.legend/pulls" aria-label="Pull Requests" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-gotokey="p" data-selected-links="repo_pulls /bebraw/Chart.js.legend/pulls">
            <span class="octicon octicon-git-pull-request"></span> <span class="full-word">Pull Requests</span>
            <span class='counter'>0</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>


        <li class="tooltipped tooltipped-w" aria-label="Wiki">
          <a href="/bebraw/Chart.js.legend/wiki" aria-label="Wiki" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="repo_wiki /bebraw/Chart.js.legend/wiki">
            <span class="octicon octicon-book"></span> <span class="full-word">Wiki</span>
            <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>
    </ul>
    <div class="sunken-menu-separator"></div>
    <ul class="sunken-menu-group">

      <li class="tooltipped tooltipped-w" aria-label="Pulse">
        <a href="/bebraw/Chart.js.legend/pulse" aria-label="Pulse" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="pulse /bebraw/Chart.js.legend/pulse">
          <span class="octicon octicon-pulse"></span> <span class="full-word">Pulse</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped tooltipped-w" aria-label="Graphs">
        <a href="/bebraw/Chart.js.legend/graphs" aria-label="Graphs" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="repo_graphs repo_contributors /bebraw/Chart.js.legend/graphs">
          <span class="octicon octicon-graph"></span> <span class="full-word">Graphs</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped tooltipped-w" aria-label="Network">
        <a href="/bebraw/Chart.js.legend/network" aria-label="Network" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-selected-links="repo_network /bebraw/Chart.js.legend/network">
          <span class="octicon octicon-git-branch"></span> <span class="full-word">Network</span>
          <img alt="Octocat-spinner-32" class="mini-loader" height="16" src="https://github.global.ssl.fastly.net/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>
    </ul>


  </div>
</div>

              <div class="only-with-full-nav">
                

  

<div class="clone-url open"
  data-protocol-type="http"
  data-url="/users/set_protocol?protocol_selector=http&amp;protocol_type=clone">
  <h3><strong>HTTPS</strong> clone URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/bebraw/Chart.js.legend.git" readonly="readonly">

    <span aria-label="copy to clipboard" class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/bebraw/Chart.js.legend.git" data-copied-hint="copied!"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>

  

<div class="clone-url "
  data-protocol-type="ssh"
  data-url="/users/set_protocol?protocol_selector=ssh&amp;protocol_type=clone">
  <h3><strong>SSH</strong> clone URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="git@github.com:bebraw/Chart.js.legend.git" readonly="readonly">

    <span aria-label="copy to clipboard" class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="git@github.com:bebraw/Chart.js.legend.git" data-copied-hint="copied!"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>

  

<div class="clone-url "
  data-protocol-type="subversion"
  data-url="/users/set_protocol?protocol_selector=subversion&amp;protocol_type=clone">
  <h3><strong>Subversion</strong> checkout URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/bebraw/Chart.js.legend" readonly="readonly">

    <span aria-label="copy to clipboard" class="js-zeroclipboard url-box-clippy minibutton zeroclipboard-button" data-clipboard-text="https://github.com/bebraw/Chart.js.legend" data-copied-hint="copied!"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>


<p class="clone-options">You can clone with
      <a href="#" class="js-clone-selector" data-protocol="http">HTTPS</a>,
      <a href="#" class="js-clone-selector" data-protocol="ssh">SSH</a>,
      or <a href="#" class="js-clone-selector" data-protocol="subversion">Subversion</a>.
  <span class="help tooltipped tooltipped-n" aria-label="Get help on which URL is right for you.">
    <a href="https://help.github.com/articles/which-remote-url-should-i-use">
    <span class="octicon octicon-question"></span>
    </a>
  </span>
</p>


  <a href="http://windows.github.com" class="minibutton sidebar-button">
    <span class="octicon octicon-device-desktop"></span>
    Clone in Desktop
  </a>

                <a href="/bebraw/Chart.js.legend/archive/master.zip"
                   class="minibutton sidebar-button"
                   title="Download this repository as a zip file"
                   rel="nofollow">
                  <span class="octicon octicon-cloud-download"></span>
                  Download ZIP
                </a>
              </div>
        </div><!-- /.repository-sidebar -->

        <div id="js-repo-pjax-container" class="repository-content context-loader-container" data-pjax-container>
          


<!-- blob contrib key: blob_contributors:v21:8b869c784b6c2568e15a4343a1aa0149 -->

<p title="This is a placeholder element" class="js-history-link-replace hidden"></p>

<a href="/bebraw/Chart.js.legend/find/master" data-pjax data-hotkey="t" class="js-show-file-finder" style="display:none">Show File Finder</a>

<div class="file-navigation">
  

<div class="select-menu js-menu-container js-select-menu" >
  <span class="minibutton select-menu-button js-menu-target" data-hotkey="w"
    data-master-branch="master"
    data-ref="master"
    role="button" aria-label="Switch branches or tags" tabindex="0" aria-haspopup="true">
    <span class="octicon octicon-git-branch"></span>
    <i>branch:</i>
    <span class="js-select-button">master</span>
  </span>

  <div class="select-menu-modal-holder js-menu-content js-navigation-container" data-pjax aria-hidden="true">

    <div class="select-menu-modal">
      <div class="select-menu-header">
        <span class="select-menu-title">Switch branches/tags</span>
        <span class="octicon octicon-remove-close js-menu-close"></span>
      </div> <!-- /.select-menu-header -->

      <div class="select-menu-filters">
        <div class="select-menu-text-filter">
          <input type="text" aria-label="Filter branches/tags" id="context-commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Filter branches/tags">
        </div>
        <div class="select-menu-tabs">
          <ul>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="branches" class="js-select-menu-tab">Branches</a>
            </li>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="tags" class="js-select-menu-tab">Tags</a>
            </li>
          </ul>
        </div><!-- /.select-menu-tabs -->
      </div><!-- /.select-menu-filters -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="branches">

        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/bebraw/Chart.js.legend/blob/gh-pages/src/legend.js"
                 data-name="gh-pages"
                 data-skip-pjax="true"
                 rel="nofollow"
                 class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target"
                 title="gh-pages">gh-pages</a>
            </div> <!-- /.select-menu-item -->
            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/bebraw/Chart.js.legend/blob/master/src/legend.js"
                 data-name="master"
                 data-skip-pjax="true"
                 rel="nofollow"
                 class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target"
                 title="master">master</a>
            </div> <!-- /.select-menu-item -->
        </div>

          <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="tags">
        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <div class="select-menu-item js-navigation-item ">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/bebraw/Chart.js.legend/tree/v0.2.0/src/legend.js"
                 data-name="v0.2.0"
                 data-skip-pjax="true"
                 rel="nofollow"
                 class="js-navigation-open select-menu-item-text js-select-button-text css-truncate-target"
                 title="v0.2.0">v0.2.0</a>
            </div> <!-- /.select-menu-item -->
        </div>

        <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

    </div> <!-- /.select-menu-modal -->
  </div> <!-- /.select-menu-modal-holder -->
</div> <!-- /.select-menu -->

  <div class="breadcrumb">
    <span class='repo-root js-repo-root'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/bebraw/Chart.js.legend" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">Chart.js.legend</span></a></span></span><span class="separator"> / </span><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/bebraw/Chart.js.legend/tree/master/src" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">src</span></a></span><span class="separator"> / </span><strong class="final-path">legend.js</strong> <span aria-label="copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-clipboard-text="src/legend.js" data-copied-hint="copied!"><span class="octicon octicon-clippy"></span></span>
  </div>
</div>


  <div class="commit file-history-tease">
    <img alt="yousifucv" class="main-avatar js-avatar" data-user="5132105" height="24" src="https://2.gravatar.com/avatar/42a18e2de35b1a46d44d571854c788ef?d=https%3A%2F%2Fidenticons.github.com%2F1854bfe2eb6edea74273fa8a0acd5552.png&amp;r=x&amp;s=140" width="24" />
    <span class="author"><a href="/yousifucv" rel="author">yousifucv</a></span>
    <time class="js-relative-date" data-title-format="YYYY-MM-DD HH:mm:ss" datetime="2013-08-05T11:40:23-07:00" title="2013-08-05 11:40:23">August 05, 2013</time>
    <div class="commit-title">
        <a href="/bebraw/Chart.js.legend/commit/546d639110551d49a12ad29ff795d050744440aa" class="message" data-pjax="true" title="Update legend.js

Added a &#39;solid&#39; style to the border. It was not visible without it (on Firefox or Chrome).">Update legend.js</a>
    </div>

    <div class="participation">
      <p class="quickstat"><a href="#blob_contributors_box" rel="facebox"><strong>3</strong> contributors</a></p>
          <a class="avatar tooltipped tooltipped-s" aria-label="loranger" href="/bebraw/Chart.js.legend/commits/master/src/legend.js?author=loranger"><img alt="Laurent Goussard" class=" js-avatar" data-user="6014" height="20" src="https://1.gravatar.com/avatar/e307069b9358189d0d6b7990f1d4b020?d=https%3A%2F%2Fidenticons.github.com%2F3f68928ec5b6fae14708854b8fd0cf08.png&amp;r=x&amp;s=140" width="20" /></a>
    <a class="avatar tooltipped tooltipped-s" aria-label="yousifucv" href="/bebraw/Chart.js.legend/commits/master/src/legend.js?author=yousifucv"><img alt="yousifucv" class=" js-avatar" data-user="5132105" height="20" src="https://2.gravatar.com/avatar/42a18e2de35b1a46d44d571854c788ef?d=https%3A%2F%2Fidenticons.github.com%2F1854bfe2eb6edea74273fa8a0acd5552.png&amp;r=x&amp;s=140" width="20" /></a>
    <a class="avatar tooltipped tooltipped-s" aria-label="bebraw" href="/bebraw/Chart.js.legend/commits/master/src/legend.js?author=bebraw"><img alt="Juho Vepsäläinen" class=" js-avatar" data-user="166921" height="20" src="https://2.gravatar.com/avatar/b26ec3c2769168c2cbc64cc3df9cdd9c?d=https%3A%2F%2Fidenticons.github.com%2Fed8ca51c3355131132e640ecbbcd78ca.png&amp;r=x&amp;s=140" width="20" /></a>


    </div>
    <div id="blob_contributors_box" style="display:none">
      <h2 class="facebox-header">Users who have contributed to this file</h2>
      <ul class="facebox-user-list">
          <li class="facebox-user-list-item">
            <img alt="Laurent Goussard" class=" js-avatar" data-user="6014" height="24" src="https://1.gravatar.com/avatar/e307069b9358189d0d6b7990f1d4b020?d=https%3A%2F%2Fidenticons.github.com%2F3f68928ec5b6fae14708854b8fd0cf08.png&amp;r=x&amp;s=140" width="24" />
            <a href="/loranger">loranger</a>
          </li>
          <li class="facebox-user-list-item">
            <img alt="yousifucv" class=" js-avatar" data-user="5132105" height="24" src="https://2.gravatar.com/avatar/42a18e2de35b1a46d44d571854c788ef?d=https%3A%2F%2Fidenticons.github.com%2F1854bfe2eb6edea74273fa8a0acd5552.png&amp;r=x&amp;s=140" width="24" />
            <a href="/yousifucv">yousifucv</a>
          </li>
          <li class="facebox-user-list-item">
            <img alt="Juho Vepsäläinen" class=" js-avatar" data-user="166921" height="24" src="https://2.gravatar.com/avatar/b26ec3c2769168c2cbc64cc3df9cdd9c?d=https%3A%2F%2Fidenticons.github.com%2Fed8ca51c3355131132e640ecbbcd78ca.png&amp;r=x&amp;s=140" width="24" />
            <a href="/bebraw">bebraw</a>
          </li>
      </ul>
    </div>
  </div>

<div class="file-box">
  <div class="file">
    <div class="meta clearfix">
      <div class="info file-name">
        <span class="icon"><b class="octicon octicon-file-text"></b></span>
        <span class="mode" title="File Mode">file</span>
        <span class="meta-divider"></span>
          <span>16 lines (13 sloc)</span>
          <span class="meta-divider"></span>
        <span>0.525 kb</span>
      </div>
      <div class="actions">
        <div class="button-group">
            <a class="minibutton tooltipped tooltipped-w"
               href="http://windows.github.com" aria-label="Open this file in GitHub for Windows">
                <span class="octicon octicon-device-desktop"></span> Open
            </a>
                <a class="minibutton tooltipped tooltipped-n js-update-url-with-hash"
                   aria-label="Clicking this button will automatically fork this project so you can edit the file"
                   href="/bebraw/Chart.js.legend/edit/master/src/legend.js"
                   data-method="post" rel="nofollow">Edit</a>
          <a href="/bebraw/Chart.js.legend/raw/master/src/legend.js" class="button minibutton " id="raw-url">Raw</a>
            <a href="/bebraw/Chart.js.legend/blame/master/src/legend.js" class="button minibutton js-update-url-with-hash">Blame</a>
          <a href="/bebraw/Chart.js.legend/commits/master/src/legend.js" class="button minibutton " rel="nofollow">History</a>
        </div><!-- /.button-group -->
          <a class="minibutton danger empty-icon tooltipped tooltipped-s"
             href="/bebraw/Chart.js.legend/delete/master/src/legend.js"
             aria-label="Fork this project and delete file"
             data-method="post" data-test-id="delete-blob-file" rel="nofollow">
          Delete
        </a>
      </div><!-- /.actions -->
    </div>
        <div class="blob-wrapper data type-javascript js-blob-data">
        <table class="file-code file-diff tab-size-8">
          <tr class="file-code-line">
            <td class="blob-line-nums">
              <span id="L1" rel="#L1">1</span>
<span id="L2" rel="#L2">2</span>
<span id="L3" rel="#L3">3</span>
<span id="L4" rel="#L4">4</span>
<span id="L5" rel="#L5">5</span>
<span id="L6" rel="#L6">6</span>
<span id="L7" rel="#L7">7</span>
<span id="L8" rel="#L8">8</span>
<span id="L9" rel="#L9">9</span>
<span id="L10" rel="#L10">10</span>
<span id="L11" rel="#L11">11</span>
<span id="L12" rel="#L12">12</span>
<span id="L13" rel="#L13">13</span>
<span id="L14" rel="#L14">14</span>
<span id="L15" rel="#L15">15</span>

            </td>
            <td class="blob-line-code"><div class="code-body highlight"><pre><div class='line' id='LC1'><span class="kd">function</span> <span class="nx">legend</span><span class="p">(</span><span class="nx">parent</span><span class="p">,</span> <span class="nx">data</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC2'>&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">parent</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;legend&#39;</span><span class="p">;</span></div><div class='line' id='LC3'>&nbsp;&nbsp;&nbsp;&nbsp;<span class="kd">var</span> <span class="nx">datas</span> <span class="o">=</span> <span class="nx">data</span><span class="p">.</span><span class="nx">hasOwnProperty</span><span class="p">(</span><span class="s1">&#39;datasets&#39;</span><span class="p">)</span> <span class="o">?</span> <span class="nx">data</span><span class="p">.</span><span class="nx">datasets</span> <span class="o">:</span> <span class="nx">data</span><span class="p">;</span></div><div class='line' id='LC4'><br/></div><div class='line' id='LC5'>&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">datas</span><span class="p">.</span><span class="nx">forEach</span><span class="p">(</span><span class="kd">function</span><span class="p">(</span><span class="nx">d</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC6'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="kd">var</span> <span class="nx">title</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createElement</span><span class="p">(</span><span class="s1">&#39;span&#39;</span><span class="p">);</span></div><div class='line' id='LC7'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">title</span><span class="p">.</span><span class="nx">className</span> <span class="o">=</span> <span class="s1">&#39;title&#39;</span><span class="p">;</span></div><div class='line' id='LC8'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">title</span><span class="p">.</span><span class="nx">style</span><span class="p">.</span><span class="nx">borderColor</span> <span class="o">=</span> <span class="nx">d</span><span class="p">.</span><span class="nx">hasOwnProperty</span><span class="p">(</span><span class="s1">&#39;strokeColor&#39;</span><span class="p">)</span> <span class="o">?</span> <span class="nx">d</span><span class="p">.</span><span class="nx">strokeColor</span> <span class="o">:</span> <span class="nx">d</span><span class="p">.</span><span class="nx">color</span><span class="p">;</span></div><div class='line' id='LC9'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">title</span><span class="p">.</span><span class="nx">style</span><span class="p">.</span><span class="nx">borderStyle</span> <span class="o">=</span> <span class="s1">&#39;solid&#39;</span><span class="p">;</span></div><div class='line' id='LC10'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">parent</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">title</span><span class="p">);</span></div><div class='line' id='LC11'><br/></div><div class='line' id='LC12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="kd">var</span> <span class="nx">text</span> <span class="o">=</span> <span class="nb">document</span><span class="p">.</span><span class="nx">createTextNode</span><span class="p">(</span><span class="nx">d</span><span class="p">.</span><span class="nx">title</span><span class="p">);</span></div><div class='line' id='LC13'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="nx">title</span><span class="p">.</span><span class="nx">appendChild</span><span class="p">(</span><span class="nx">text</span><span class="p">);</span></div><div class='line' id='LC14'>&nbsp;&nbsp;&nbsp;&nbsp;<span class="p">});</span></div><div class='line' id='LC15'><span class="p">}</span></div></pre></div></td>
          </tr>
        </table>
  </div>

  </div>
</div>

<a href="#jump-to-line" rel="facebox[.linejump]" data-hotkey="l" class="js-jump-to-line" style="display:none">Jump to Line</a>
<div id="jump-to-line" style="display:none">
  <form accept-charset="UTF-8" class="js-jump-to-line-form">
    <input class="linejump-input js-jump-to-line-field" type="text" placeholder="Jump to line&hellip;" autofocus>
    <button type="submit" class="button">Go</button>
  </form>
</div>

        </div>

      </div><!-- /.repo-container -->
      <div class="modal-backdrop"></div>
    </div><!-- /.container -->
  </div><!-- /.site -->


    </div><!-- /.wrapper -->

      <div class="container">
  <div class="site-footer">
    <ul class="site-footer-links right">
      <li><a href="https://status.github.com/">Status</a></li>
      <li><a href="http://developer.github.com">API</a></li>
      <li><a href="http://training.github.com">Training</a></li>
      <li><a href="http://shop.github.com">Shop</a></li>
      <li><a href="/blog">Blog</a></li>
      <li><a href="/about">About</a></li>

    </ul>

    <a href="/">
      <span class="mega-octicon octicon-mark-github" title="GitHub"></span>
    </a>

    <ul class="site-footer-links">
      <li>&copy; 2014 <span title="0.04485s from github-fe128-cp1-prd.iad.github.net">GitHub</span>, Inc.</li>
        <li><a href="/site/terms">Terms</a></li>
        <li><a href="/site/privacy">Privacy</a></li>
        <li><a href="/security">Security</a></li>
        <li><a href="/contact">Contact</a></li>
    </ul>
  </div><!-- /.site-footer -->
</div><!-- /.container -->


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-fullscreen-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="js-fullscreen-contents" placeholder="" data-suggester="fullscreen_suggester"></textarea>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped tooltipped-w" aria-label="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped tooltipped-w"
      aria-label="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      <a href="#" class="octicon octicon-remove-close close js-ajax-error-dismiss"></a>
      Something went wrong with that request. Please try again.
    </div>

  </body>
</html>

