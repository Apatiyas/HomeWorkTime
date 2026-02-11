#pragma once
#include "FileName.h"
#include <iostream>
#include <filesystem>
#include "stream_execeptions.h"

class ReadFile : public BaseFile {
public:
	ReadFile(std::string path) :BaseFile(path) { open(path); }

	void close() override {
		if (pstream && pstream->rdbuf()) {
			std::filebuf* fb = static_cast<std::filebuf*>(pstream->rdbuf());
			fb->close();
		}

		delete pstream;
		pstream = nullptr;
	}

	
	void open(std::string path) override {
		std::filesystem::path fname = path;
		if (!std::filesystem::exists(fname)) {
			throw not_found_error("File not found");
		}

		pstream = new std::ifstream(path);
		if (pstream && pstream->rdbuf()) {
			std::filebuf* fb = static_cast<std::filebuf*>(pstream->rdbuf());

			if (!fb->is_open()) {

				delete pstream;
				pstream = nullptr;
				throw not_found_error("Common file open error");
			}
		}
	}


	void read_text() {
		
		
		std::istream* stream = dynamic_cast<std::istream*>(pstream);

		if (stream) {
			std::string line;
			while (std::getline(*stream, line)) {
				std::cout << line << std::endl;
		
			}
		}

		delete pstream;
		pstream = nullptr;
	}
	~ReadFile() { close(); }
};