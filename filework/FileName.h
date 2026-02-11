#pragma once
#include <iostream>
#include <string>
#include <fstream>
#include <xiosbase>
#include <filesystem>
#include "stream_execeptions.h"


class BaseFile {
protected:
    std::basic_ios<char, std::char_traits<char>>* pstream = nullptr;

public:
  
    BaseFile(std::string path) { }

    virtual void open(std::string path) = 0;

    virtual ~BaseFile() = default;
    virtual void close() = 0;
};
