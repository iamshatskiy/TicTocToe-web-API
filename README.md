# TicTocToe-web-API

- проект собирается в Docker и разворачивается в рабочее состоение docker-compose
- [публикация API в Docker Hub](https://hub.docker.com/r/panindog/tictactoe/)


 
# Описание API
    
<div class="app-desc">Web-API для игры в крестики-нолики 3x3 для двух игроков.</div>
    <div class="app-desc">More information: [https://helloreverb.com](https://helloreverb.com/)</div>
    <div class="app-desc">Contact Info: [hello@helloreverb.com](hello@helloreverb.com)</div>
    <div class="app-desc">Version: 1.0</div>
    
    <div class="license-info">All rights reserved</div>
    <div class="license-url">http://apache.org/licenses/LICENSE-2.0.html</div>
  
## Access
    

      
1. APIKey KeyParamName:Authorization KeyInQuery:false KeyInHeader:true
    

  
## [Methods]()
  [ Jump to [Models](#__Models) ]

  
### Table of Contents 
  
<div class="method-summary"></div>
  
#### [PlayField](#PlayField)
  
  
- [`<span class="http-method">post</span> /api/PlayField/create`](#apiPlayFieldCreatePost)
  
- [`<span class="http-method">get</span> /api/PlayField/getall`](#apiPlayFieldGetallGet)
  
- [`<span class="http-method">delete</span> /api/PlayField/{id}`](#apiPlayFieldIdDelete)
  
- [`<span class="http-method">get</span> /api/PlayField/{id}`](#apiPlayFieldIdGet)
  
- [`<span class="http-method">patch</span> /api/PlayField/update`](#apiPlayFieldUpdatePatch)
  

  
# [PlayField]()
  
<div class="method">[]()
    <div class="method-path">
    [Up](#__Methods)
        <span class="http-method">post</span> /api/PlayField/create
</div>
    <div class="method-summary"> (<span class="nickname">apiPlayFieldCreatePost</span>)</div>
    <div class="method-notes">Метод предназначен для создания нового игрового поля. Возможность создания индивидуального игрового поля может быть добавлена в последующих версиях.</div>


    
### Consumes
    This API call consumes the following media types via the <span class="header">Content-Type</span> request header:
    
      
- `application/json`
      
- `text/json`
      
- `application/*+json`
    

    
### Request body
    
<div class="field-items">
      <div class="param">body [PFModel](#PFModel) (optional)</div>
      
            <div class="param-desc"><span class="param-type">Body Parameter</span> —  </div>
                </div>  





    



    
### Responses
    
#### 200
    Доска успешно создана.
        []()
    
#### 500
    Нет доступа.
        []()
  </div> 
  
- - -
  
<div class="method">[]()
    <div class="method-path">
    [Up](#__Methods)
        <span class="http-method">get</span> /api/PlayField/getall
</div>
    <div class="method-summary"> (<span class="nickname">apiPlayFieldGetallGet</span>)</div>
    <div class="method-notes">Метод получения всех игровых полей.</div>








    



    
### Responses
    
#### 200
    Запрос на получение всех текущих игровых полей успешен.
        []()
  </div> 
  
- - -
  
<div class="method">[]()
    <div class="method-path">
    [Up](#__Methods)
        <span class="http-method">delete</span> /api/PlayField/{id}
</div>
    <div class="method-summary"> (<span class="nickname">apiPlayFieldIdDelete</span>)</div>
    <div class="method-notes">Метод удаления игрового поля по ID.</div>

    
### Path parameters
    
<div class="field-items">
      <div class="param">id (required)</div>
      
            <div class="param-desc"><span class="param-type">Path Parameter</span> — ID игрового поля. format: int32</div>    </div>  







    



    
### Responses
    
#### 200
    Запрос на удаление успешно выполнен
        []()
  </div> 
  
- - -
  
<div class="method">[]()
    <div class="method-path">
    [Up](#__Methods)
        <span class="http-method">get</span> /api/PlayField/{id}
</div>
    <div class="method-summary"> (<span class="nickname">apiPlayFieldIdGet</span>)</div>
    <div class="method-notes">Метод получения игрового поля по ID.</div>

    
### Path parameters
    
<div class="field-items">
      <div class="param">id (required)</div>
      
            <div class="param-desc"><span class="param-type">Path Parameter</span> — ID игрового поля. format: int32</div>    </div>  







    



    
### Responses
    
#### 200
    Запрос успешно выполнен.
        []()
  </div> 
  
- - -
  
<div class="method">[]()
    <div class="method-path">
    [Up](#__Methods)
        <span class="http-method">patch</span> /api/PlayField/update
</div>
    <div class="method-summary"> (<span class="nickname">apiPlayFieldUpdatePatch</span>)</div>
    <div class="method-notes">Метод реализации хода игрока. Каждый четный ход делает первый игрок, в игровую клетку присваивается '1' -- 'крестик', при нечетном ходе -- игровой клетке вторым игроком присваивается числовое значение: '2' -- 'нолик'. В случае выигрыша или ничьи -- игроки получают соответствующее сообщение</div>


    
### Consumes
    This API call consumes the following media types via the <span class="header">Content-Type</span> request header:
    
      
- `application/json`
      
- `text/json`
      
- `application/*+json`
    

    
### Request body
    
<div class="field-items">
      <div class="param">body [UpdatePlayFieldRequest](#UpdatePlayFieldRequest) (optional)</div>
      
            <div class="param-desc"><span class="param-type">Body Parameter</span> —  </div>
                </div>  





    



    
### Responses
    
#### 200
    Успешно выполненный запрос.
        []()
  </div> 
  
- - -

  
## [Models]()
  [ Jump to [Methods](#__Methods) ]

  
### Table of Contents
  

    
1. [`PFModel`](#PFModel)
    
1. [`UpdatePlayFieldRequest`](#UpdatePlayFieldRequest)
  

  
<div class="model">
    
### [`PFModel`]() [Up](#__Models)
    
    
<div class="field-items">
      <div class="param">id (optional)</div><div class="param-desc"><span class="param-type">[Integer](#integer)</span> ID игрового поля. format: int32</div>
<div class="param">turn (optional)</div>
<div class="param-desc"><span class="param-type">[Integer](#integer)</span> Индекс хода игроков (четный -- первый игрок, нечетный -- второй игрок). format: int32</div>
<div class="param">pf (optional)</div>
<div class="param-desc"><span class="param-type">[array[Integer]](#integer)</span> Игровое поле в виде одномерного массива. format: int32</div>
    </div>  
  </div>
  <div class="model">
    ### [`UpdatePlayFieldRequest`]() [Up](#__Models)
    
    <div class="field-items">
      <div class="param">pFuk </div><div class="param-desc"><span class="param-type">[Integer](#integer)</span> ID игрового поля. format: int32</div>
<div class="param">n </div><div class="param-desc"><span class="param-type">[Integer](#integer)</span> Строка игрового поля. format: int32</div>
<div class="param">m </div><div class="param-desc"><span class="param-type">[Integer](#integer)</span> Столбец игрового поля. format: int32</div>
    </div>  
  </div>
  

